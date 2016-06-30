using Autofac;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TOriginLocationCifRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;
        
        public TOriginLocationCifRecordParser()
        {
            var builder = SchedulePropertyParsersContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _container = builder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
        }

        private static OriginLocationCifRecordParser BuildParser()
        {
            return new OriginLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);
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