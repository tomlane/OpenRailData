using Microsoft.Practices.Unity;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
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