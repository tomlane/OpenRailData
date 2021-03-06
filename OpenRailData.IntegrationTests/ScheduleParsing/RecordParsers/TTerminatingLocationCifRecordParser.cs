﻿using Autofac;
using NodaTime;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TTerminatingLocationCifRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TTerminatingLocationCifRecordParser()
        {
            var builder = ScheduleModuleContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _container = builder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private TerminatingLocationCifRecordParser BuildParser()
        {
            return new TerminatingLocationCifRecordParser(_enumPropertyParsers);
        }
        
        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "LTWSTBRYW 1323 13253     TF                                                     ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LT,
                Tiploc = "WSTBRYW",
                WorkingArrival = new LocalTime(13, 23),
                PublicArrival = new LocalTime(13, 25),
                Platform = "3",
                LocationActivity = LocationActivity.TF,
                LocationActivityString = "TF          ",
                OrderTime = new LocalTime(13, 23)
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }
    }
}