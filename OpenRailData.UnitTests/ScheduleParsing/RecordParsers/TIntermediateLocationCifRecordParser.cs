using System;
using Microsoft.Practices.Unity;
using Moq;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TIntermediateLocationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;

        public TIntermediateLocationCifRecordParser()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
        }

        private static IntermediateLocationCifRecordParser BuildParser()
        {
            return new IntermediateLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(enumPropertyParsers, null));
        }

        [Fact]
        public void throws_when_argument_is_null()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t "));
        }

        [Fact]
        public void returns_correct_property_key()
        {
            var recordParser = BuildParser();

            Assert.Equal("LI", recordParser.RecordKey);
        }

        [Fact]
        public void returns_expected_result_arrival_and_departure()
        {
            var recordParser = BuildParser();
            var recordToParse = "LIMELKSHM 1307H1308      13081308         T                                     ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LI,
                Tiploc = "MELKSHM",
                WorkingArrival = "1307H",
                PublicArrival = "1308",
                WorkingDeparture = "1308",
                PublicDeparture = "1308",
                LocationActivity = LocationActivity.T,
                LocationActivityString = "T           ",
                OrderTime = "1308",
                Pass = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_expected_result_pass()
        {
            var recordParser = BuildParser();
            var recordToParse = "LIBRDFDJN           1314 00000000                                               ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LI,
                Tiploc = "BRDFDJN",
                Pass = "1314",
                OrderTime = "1314",
                LocationActivityString = "            ",
                PublicArrival = string.Empty,
                PublicDeparture = string.Empty,
                WorkingDeparture = string.Empty,
                WorkingArrival = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}