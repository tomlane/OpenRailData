using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TIntermediateLocationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static ITimingAllowanceParser _timingAllowanceParser;

        [SetUp]
        public void Setup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
        }

        private static IntermediateLocationCifRecordParser BuildParser()
        {
            return new IntermediateLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(enumPropertyParsers, null));
        }

        [Test]
        public void returns_expected_result_arrival_and_departure()
        {
            var recordParser = BuildParser();
            var recordToParse = "LIMELKSHM 1307H1308      13081308         T                                     ";
            var expectedResult = new LocationRecord
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
            
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_result_pass()
        {
            var recordParser = BuildParser();
            var recordToParse = "LIBRDFDJN           1314 00000000                                               ";
            var expectedResult = new LocationRecord
            {
                RecordIdentity = ScheduleRecordType.LI,
                Tiploc = "BRDFDJN",
                Pass = "1314",
                OrderTime = "1314",
                LocationActivityString = "            ",
                PublicArrival = "0000",
                PublicDeparture = "0000",
                WorkingDeparture = string.Empty,
                WorkingArrival = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}