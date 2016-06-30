using System;
using System.Collections.Generic;
using Autofac;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TJsonScheduleRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;

        public TJsonScheduleRecordParser()
        {
            var builder = SchedulePropertyParsersContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
        }
        
        private JsonScheduleRecordParser BuildParser()
        {
            return new JsonScheduleRecordParser(_enumPropertyParsers, _timingAllowanceParser);
        }

        [Fact(Skip = "Need to check list comparison")]
        public void parse_record_parses_create_schedule_record_correctly()
        {
            var message = "{\"JsonScheduleV1\":{\"CIF_bank_holiday_running\":null,\"CIF_stp_indicator\":\"P\",\"CIF_train_uid\":\"C41389\",\"applicable_timetable\":\"Y\",\"atoc_code\":\"GW\",\"new_schedule_segment\":{\"traction_class\":\"\",\"uic_code\":\"\"},\"schedule_days_runs\":\"0000100\",\"schedule_end_date\":\"2016-12-09\",\"schedule_segment\":{\"signalling_id\":\"1A40\",\"CIF_train_category\":\"XZ\",\"CIF_headcode\":\"1218\",\"CIF_course_indicator\":1,\"CIF_train_service_code\":\"25396002\",\"CIF_business_sector\":\"??\",\"CIF_power_type\":\"D\",\"CIF_timing_load\":\"350\",\"CIF_speed\":\"075\",\"CIF_operating_characteristics\":\"Q\",\"CIF_train_class\":\"S\",\"CIF_sleepers\":\"S\",\"CIF_reservations\":\"R\",\"CIF_connection_indicator\":null,\"CIF_catering_code\":\"C\",\"CIF_service_branding\":\"\",\"schedule_location\":[{\"location_type\":\"LO\",\"record_identity\":\"LO\",\"tiploc_code\":\"PENZNCE\",\"tiploc_instance\":null,\"departure\":\"2145\",\"public_departure\":\"2145\",\"platform\":\"4\",\"line\":null,\"engineering_allowance\":null,\"pathing_allowance\":null,\"performance_allowance\":null},{\"location_type\":\"LI\",\"record_identity\":\"LI\",\"tiploc_code\":\"LNGROCK\",\"tiploc_instance\":null,\"arrival\":null,\"departure\":null,\"pass\":\"2149\",\"public_arrival\":null,\"public_departure\":null,\"platform\":null,\"line\":null,\"path\":null,\"engineering_allowance\":null,\"pathing_allowance\":null,\"performance_allowance\":null},{\"location_type\":\"LT\",\"record_identity\":\"LT\",\"tiploc_code\":\"PADTON\",\"tiploc_instance\":null,\"arrival\":\"0508\",\"public_arrival\":\"0512\",\"platform\":\"1\",\"path\":null}]},\"schedule_start_date\":\"2016-05-20\",\"train_status\":\"P\",\"transaction_type\":\"Create\"}}";

            var schedule = new ScheduleRecord
            {
                TrainServiceCode = "25396002",
                StpIndicator = StpIndicator.P,
                RecordIdentity = ScheduleRecordType.BSN,
                TrainUid = "C41389",
                ScheduleLocations = new List<ScheduleLocationRecord>
                {
                    new ScheduleLocationRecord
                    {
                        Tiploc = "PENZNCE",
                        RecordIdentity = ScheduleRecordType.LO,
                        Platform = "4",
                        Line = string.Empty,
                        EngineeringAllowance = new TimeSpan(),
                        LocationActivity = 0,
                        LocationActivityString = string.Empty,
                        OrderTime = "2145",
                        Pass = string.Empty,
                        Path = string.Empty,
                        PathingAllowance = new TimeSpan(),
                        PerformanceAllowance = new TimeSpan(),
                        PublicArrival = string.Empty,
                        PublicDeparture = "2145",
                        TiplocSuffix = string.Empty,
                        WorkingArrival = string.Empty,
                        WorkingDeparture = "2145"
                    },
                    new ScheduleLocationRecord
                    {
                        Tiploc = "LNGROCK",
                        RecordIdentity = ScheduleRecordType.LI,
                        Platform = string.Empty,
                        Line = string.Empty,
                        Pass = "2149",
                        WorkingArrival = string.Empty,
                        OrderTime = "2149",
                        TiplocSuffix = string.Empty,
                        WorkingDeparture = string.Empty,
                        LocationActivity = 0,
                        EngineeringAllowance = new TimeSpan(),
                        PerformanceAllowance = new TimeSpan(),
                        PublicDeparture = string.Empty,
                        PublicArrival = string.Empty,
                        PathingAllowance = new TimeSpan(),
                        LocationActivityString = string.Empty,
                        Path = string.Empty
                    },
                    new ScheduleLocationRecord
                    {
                        Tiploc = "PADTON",
                        RecordIdentity = ScheduleRecordType.LT,
                        Platform = "1",
                        Line = string.Empty,
                        Pass = string.Empty,
                        WorkingArrival = "0508",
                        OrderTime = "0508",
                        TiplocSuffix = string.Empty,
                        WorkingDeparture = string.Empty,
                        LocationActivity = 0,
                        EngineeringAllowance = new TimeSpan(),
                        PerformanceAllowance = new TimeSpan(),
                        PublicDeparture = string.Empty,
                        PublicArrival = "0512",
                        PathingAllowance = new TimeSpan(),
                        LocationActivityString = string.Empty,
                        Path = string.Empty
                    }
                },
                AtocCode = "GW",
                AtsCode = string.Empty,
                BankHolidayRunning = BankHolidayRunning.X,
                CateringCode = CateringCode.C,
                ConnectionIndicator = string.Empty,
                CourseIndicator = "1",
                DataSource = string.Empty,
                StartDate = new DateTime(2016, 5, 20),
                EndDate = new DateTime(2016, 12, 9),
                HeadCode = "1218",
                OperatingCharacteristics = OperatingCharacteristics.Q,
                OperatingCharacteristicsString = "Q",
                PortionId = string.Empty,
                PowerType = PowerType.D,
                Reservations = ReservationDetails.R,
                Rsid = string.Empty,
                RunningDays = Days.Friday,
                SeatingClass = SeatingClass.S,
                ServiceBranding = ServiceBranding.None,
                ServiceTypeFlags = 0,
                Sleepers = SleeperDetails.S,
                Speed = 75,
                TimingLoad = "350",
                TrainCategory = "XZ",
                TrainIdentity = "1A40",
                TrainStatus = string.Empty,
                UicCode = string.Empty,
                UniqueId = string.Empty
            };

            var parser = BuildParser();

            var result = parser.ParseRecord(message);

            Assert.Equal(schedule, result);
        }

        [Fact(Skip = "Need to check list comparison")]
        public void parse_record_parses_delete_schedule_record_correctly()
        {
            var message = "{\"JsonScheduleV1\":{\"CIF_train_uid\":\"H32365\",\"schedule_start_date\":\"2016-06-17\",\"CIF_stp_indicator\":\"C\",\"transaction_type\":\"Delete\"}}";

            var schedule = new ScheduleRecord
            {
                TrainUid = "H32365",
                StartDate = new DateTime(2016, 6, 17),
                StpIndicator = StpIndicator.C,
                RecordIdentity = ScheduleRecordType.BSD,
                UniqueId = "H3236520160617C"
            };

            var parser = BuildParser();

            var result = parser.ParseRecord(message);

            Assert.Equal(schedule, result);
        }
    }
}