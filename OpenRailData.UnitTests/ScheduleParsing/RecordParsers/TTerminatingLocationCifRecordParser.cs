using System;
using Microsoft.Practices.Unity;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TTerminatingLocationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TTerminatingLocationCifRecordParser()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private TerminatingLocationCifRecordParser BuildParser()
        {
            return new TerminatingLocationCifRecordParser(_enumPropertyParsers);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TerminatingLocationCifRecordParser(null));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("LT", parser.RecordKey);
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
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "LTWSTBRYW 1323 13253     TF                                                     ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LT,
                Tiploc = "WSTBRYW",
                WorkingArrival = "1323",
                PublicArrival = "1325",
                Platform = "3",
                LocationActivity = LocationActivity.TF,
                LocationActivityString = "TF          ",
                OrderTime = "1323"
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}
