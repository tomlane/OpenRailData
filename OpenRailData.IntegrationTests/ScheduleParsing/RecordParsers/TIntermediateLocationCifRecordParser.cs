using Autofac;
using NodaTime;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TIntermediateLocationCifRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;

        public TIntermediateLocationCifRecordParser()
        {
            var builder = ScheduleModuleContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _container = builder.Build();

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
                WorkingArrival = new LocalTime(13, 07, 30),
                PublicArrival = new LocalTime(13, 08),
                WorkingDeparture = new LocalTime(13, 08),
                PublicDeparture = new LocalTime(13, 08),
                LocationActivity = LocationActivity.T,
                LocationActivityString = "T           ",
                OrderTime = new LocalTime(13, 08),
                Pass = null
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
                Pass = new LocalTime(13, 14),
                OrderTime = new LocalTime(13, 14),
                LocationActivityString = "            ",
                PublicArrival = null,
                PublicDeparture = null,
                WorkingDeparture = null,
                WorkingArrival = null
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }
    }
}