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
    
    public class TOriginLocationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(enumPropertyParsers, null));
        }

        public TOriginLocationCifRecordParser()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
        }
        
        private static OriginLocationCifRecordParser BuildParser()
        {
            return new OriginLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);
        }

        [Fact]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(" \t "));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("LO", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "LOSDON    1242 12422         TB                                                 ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LO,
                Tiploc = "SDON",
                WorkingDeparture = "1242",
                PublicDeparture = "1242",
                Platform = "2",
                LocationActivity = LocationActivity.TB,
                LocationActivityString = "TB          ",
                OrderTime = "1242"
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}
