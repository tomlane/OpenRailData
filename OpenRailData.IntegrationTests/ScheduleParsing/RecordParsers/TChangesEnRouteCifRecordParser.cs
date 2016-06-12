﻿using System;
using Microsoft.Practices.Unity;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TChangesEnRouteCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TChangesEnRouteCifRecordParser()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private static ChangesEnRouteCifRecordParser BuildParser()
        {
            return new ChangesEnRouteCifRecordParser(_enumPropertyParsers);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "CRHULL    XX1J22    111808920 DMUS   075      S S                               ";
            var expectedResult = new ChangesEnRouteRecord
            {
                RecordIdentity = ScheduleRecordType.CR,
                Tiploc = "HULL",
                TiplocSuffix = string.Empty,
                Category = "XX",
                TrainIdentity = "1J22",
                HeadCode = string.Empty,
                CourseIndicator = "1",
                ServiceCode = "11808920",
                PortionId = string.Empty,
                PowerType = PowerType.DMU,
                TimingLoad = "S",
                Speed = 075,
                OperatingCharacteristics = string.Empty,
                SeatingClass = SeatingClass.S,
                Sleepers = SleeperDetails.NotAvailable,
                Reservations = ReservationDetails.S,
                ConnectionIndicator = string.Empty,
                CateringCode = 0,
                ServiceBranding = ServiceBranding.None,
                UicCode = string.Empty,
                Rsid = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }
    }
}