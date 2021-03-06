﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using OpenRailData.ScheduleParsing.Json.RawRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonScheduleRecordParser : IScheduleRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _propertyParsers;
        private readonly ITimingAllowanceParser _timingAllowanceParser;

        public JsonScheduleRecordParser(IRecordEnumPropertyParser[] propertyParsers, ITimingAllowanceParser timingAllowanceParser)
        {
            if (propertyParsers == null)
                throw new ArgumentNullException(nameof(propertyParsers));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));

            _propertyParsers = propertyParsers.ToDictionary(x => x.PropertyKey, x => x);
            _timingAllowanceParser = timingAllowanceParser;
        }

        public string RecordKey { get; } = "JsonScheduleV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(recordString));

            var deserializedSchedule = JsonConvert.DeserializeObject<DeserializedRecord>(recordString);

            var schedule = new ScheduleRecord
            {
                TrainServiceCode = deserializedSchedule?.Schedule?.ScheduleSegment?.TrainServiceCode ?? string.Empty,
                StpIndicator = (StpIndicator)_propertyParsers["StpIndicator"].ParseProperty(deserializedSchedule?.Schedule?.StpIndicator),
                TrainUid = deserializedSchedule?.Schedule?.TrainUid ?? string.Empty,
                AtocCode = deserializedSchedule?.Schedule?.AtocCode ?? string.Empty,
                AtsCode = string.Empty,
                BankHolidayRunning = (BankHolidayRunning)_propertyParsers["BankHolidayRunning"].ParseProperty(deserializedSchedule?.Schedule?.BankHolidayRunning),
                CateringCode = (CateringCode)_propertyParsers["CateringCode"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.CateringCode),
                ConnectionIndicator = string.Empty,
                CourseIndicator = deserializedSchedule?.Schedule?.ScheduleSegment?.CourseIndicator ?? string.Empty,
                DataSource = string.Empty,
                StartDate = DateTime.ParseExact(deserializedSchedule?.Schedule?.ScheduleStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                HeadCode = deserializedSchedule?.Schedule?.ScheduleSegment?.HeadCode,
                OperatingCharacteristics = (OperatingCharacteristics)_propertyParsers["OperatingCharacteristics"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.OperatingCharacteristics),
                OperatingCharacteristicsString = deserializedSchedule?.Schedule?.ScheduleSegment?.OperatingCharacteristics ?? string.Empty,
                PortionId = string.Empty,
                PowerType = (PowerType)_propertyParsers["PowerType"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.PowerType),
                Reservations = (ReservationDetails)_propertyParsers["ReservationDetails"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.Reservations),
                Rsid = string.Empty,
                RunningDays = (Days)_propertyParsers["RunningDays"].ParseProperty(deserializedSchedule?.Schedule?.DaysRuns),
                SeatingClass = (SeatingClass)_propertyParsers["SeatingClass"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.TrainClass),
                ServiceBranding = (ServiceBranding)_propertyParsers["ServiceBranding"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.ServiceBranding),
                ServiceTypeFlags = 0,
                Sleepers = (SleeperDetails)_propertyParsers["SleeperDetails"].ParseProperty(deserializedSchedule?.Schedule?.ScheduleSegment?.Sleepers),
                TimingLoad = deserializedSchedule?.Schedule?.ScheduleSegment?.TimingLoad ?? string.Empty,
                TrainCategory = deserializedSchedule?.Schedule?.ScheduleSegment?.TrainCategory ?? string.Empty,
                TrainIdentity = deserializedSchedule?.Schedule?.ScheduleSegment?.SignallingId ?? string.Empty,
                TrainStatus = string.Empty,
                UicCode = deserializedSchedule?.Schedule?.NewScheduleSegment?.UicCode ?? string.Empty
            };

            schedule.UniqueId = $"{schedule.TrainUid}{schedule.StartDate.ToString("yyyyMMdd")}{schedule.StpIndicator}";

            if (!string.IsNullOrWhiteSpace(deserializedSchedule?.Schedule?.ScheduleEndDate))
                schedule.EndDate = DateTime.ParseExact(deserializedSchedule?.Schedule?.ScheduleEndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

            if (!string.IsNullOrWhiteSpace(deserializedSchedule?.Schedule?.ScheduleSegment?.Speed))
                schedule.Speed = int.Parse(deserializedSchedule.Schedule?.ScheduleSegment?.Speed);

            var scheduleLocations = deserializedSchedule?.Schedule?.ScheduleSegment?.ScheduleLocations;

            if (scheduleLocations != null && scheduleLocations.Any())
            {
                foreach (var scheduleLocation in deserializedSchedule.Schedule.ScheduleSegment.ScheduleLocations)
                {
                    schedule.ScheduleLocations.Add(ParseScheduleLocation(scheduleLocation));
                }
            }

            switch (deserializedSchedule?.Schedule?.TransactionType)
            {
                case "Create":
                    schedule.RecordIdentity = ScheduleRecordType.BSN;
                    break;
                case "Delete":
                    schedule.RecordIdentity = ScheduleRecordType.BSD;
                    break;
                default:
                    throw new ArgumentException("Unable to obtain Schedule transaction type.");
            }

            return schedule;
        }

        private ScheduleLocationRecord ParseScheduleLocation(ScheduleLocation location)
        {
            var locationRecord = new ScheduleLocationRecord
            {
                EngineeringAllowance = _timingAllowanceParser.ParseTime(location.EngineeringAllowance),
                Line = location.Line ?? string.Empty,
                LocationActivity = 0,
                LocationActivityString = string.Empty,
                Pass = ScheduleLocationTimeParser.ParseLocationTimeString(location.Pass),
                Path = location.Path ?? string.Empty,
                PathingAllowance = _timingAllowanceParser.ParseTime(location.PathingAllowance),
                PerformanceAllowance = _timingAllowanceParser.ParseTime(location.PerformanceAllowance),
                Platform = location.Platform ?? string.Empty,
                PublicArrival = ScheduleLocationTimeParser.ParseLocationTimeString(location.PublicArrival),
                PublicDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(location.PublicDeparture),
                Tiploc = location.TiplocCode,
                TiplocSuffix = location.TiplocInstance ?? string.Empty,
                WorkingArrival = ScheduleLocationTimeParser.ParseLocationTimeString(location.WorkingArrival),
                WorkingDeparture = ScheduleLocationTimeParser.ParseLocationTimeString(location.WorkingDeparture)
            };

            switch (location.LocationType)
            {
                case "LO":
                    locationRecord.RecordIdentity = ScheduleRecordType.LO;
                    locationRecord.OrderTime = locationRecord.WorkingDeparture;
                    break;
                case "LI":
                    locationRecord.RecordIdentity = ScheduleRecordType.LI;
                    locationRecord.OrderTime = locationRecord.Pass ?? locationRecord.WorkingDeparture;
                    break;
                case "LT":
                    locationRecord.RecordIdentity = ScheduleRecordType.LT;
                    locationRecord.OrderTime = locationRecord.WorkingArrival;
                    break;
            }

            return locationRecord;
        }
    }
}