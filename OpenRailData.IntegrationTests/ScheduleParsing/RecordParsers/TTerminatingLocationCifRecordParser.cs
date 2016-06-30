using Autofac;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TTerminatingLocationCifRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TTerminatingLocationCifRecordParser()
        {
            var builder = SchedulePropertyParsersContainerBuilder.Build();
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