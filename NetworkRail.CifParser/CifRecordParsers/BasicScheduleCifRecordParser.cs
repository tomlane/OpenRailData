using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public class BasicScheduleCifRecordParser : IScheduleRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers;
        private readonly IDateTimeParser _dateTimeParser;
        
        public BasicScheduleCifRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers, IDateTimeParser dateTimeParser)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
            _dateTimeParser = dateTimeParser;
        }

        public string RecordKey { get; } = "BS";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            BasicScheduleRecord record = new BasicScheduleRecord
            {
                TransactionType = (TransactionType)_enumPropertyParsers["TransactionType"].ParseProperty(recordString.Substring(2, 1)),
                TrainUid = recordString.Substring(3, 6),
                DateRunsTo = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yyMMdd",
                    DateTimeString = recordString.Substring(15, 6)
                }),
                RunningDays = (Days)_enumPropertyParsers["RunningDays"].ParseProperty(recordString.Substring(21, 7)),
                BankHolidayRunning = (BankHolidayRunning)_enumPropertyParsers["BankHolidayRunning"].ParseProperty(recordString.Substring(28, 1)),
                TrainStatus = recordString.Substring(29, 1).Trim(),
                TrainCategory = recordString.Substring(30, 2).Trim(),
                TrainIdentity = recordString.Substring(32, 4).Trim(),
                HeadCode = recordString.Substring(36, 4).Trim(),
                CourseIndicator = recordString.Substring(40, 1).Trim(),
                TrainServiceCode = recordString.Substring(41, 8).Trim(),
                PortionId = recordString.Substring(49, 1).Trim(),
                PowerType = (PowerType)_enumPropertyParsers["PowerType"].ParseProperty(recordString.Substring(50, 3).Trim()),
                TimingLoad = recordString.Substring(53, 4).Trim(),
                OperatingCharacteristicsString = recordString.Substring(60, 6),
                SeatingClass = (SeatingClass)_enumPropertyParsers["SeatingClass"].ParseProperty(recordString.Substring(66, 1)),
                Sleepers = (SleeperDetails)_enumPropertyParsers["SleeperDetails"].ParseProperty(recordString.Substring(67, 1)),
                Reservations = (ReservationDetails)_enumPropertyParsers["ReservationDetails"].ParseProperty(recordString.Substring(68, 1)),
                ConnectionIndicator = recordString.Substring(69, 1).Trim(),
                CateringCode = (CateringCode)_enumPropertyParsers["CateringCode"].ParseProperty(recordString.Substring(70, 4).Trim()),
                ServiceBranding = (ServiceBranding)_enumPropertyParsers["ServiceBranding"].ParseProperty(recordString.Substring(74, 4).Trim()),
                StpIndicator = (StpIndicator)_enumPropertyParsers["StpIndicator"].ParseProperty(recordString.Substring(79, 1))
            };

            int speed;
            bool speedParsed = int.TryParse(recordString.Substring(57, 3).Trim(), NumberStyles.Any,
                new CultureInfo("en-gb"), out speed);

            if (speedParsed)
                record.Speed = speed;

            var dateRunsFromResult = _dateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = recordString.Substring(9, 6)
            });

            if (dateRunsFromResult.HasValue)
                record.DateRunsFrom = dateRunsFromResult.Value;
            else
            {
                throw new ArgumentException("Failed to parse Date Runs From in Basic Schedule Record");
            }

            record.UniqueId = record.TrainUid + recordString.Substring(9, 6) + record.StpIndicator;

            if (record.TrainCategory == "BR" || record.TrainCategory == "BS")
            {
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Bus;
                record.ServiceTypeFlags = record.ServiceTypeFlags &= ~ServiceTypeFlags.Train;
            }
            else if (record.TrainStatus == "S" || record.TrainStatus == "4")
            {
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Ship;
                record.ServiceTypeFlags = record.ServiceTypeFlags &= ~ServiceTypeFlags.Train;
            }

            if (record.ServiceTypeFlags.HasFlag(ServiceTypeFlags.Bus) || record.ServiceTypeFlags.HasFlag(ServiceTypeFlags.Ship) || 
                record.TrainCategory == "OL" || record.TrainCategory == "OO" || record.TrainCategory == "XC" || record.TrainCategory == "XX" || record.TrainCategory == "XZ")
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Passenger;

            record.OperatingCharacteristics = (OperatingCharacteristics)_enumPropertyParsers["OperatingCharacteristics"].ParseProperty(record.OperatingCharacteristicsString);

            return record;
        }
    }
}