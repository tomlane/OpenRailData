using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
{
    [TestFixture]
    public class TIntermediateLocationCifRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(enumPropertyParsers, null));
        }

        [TestFixture]
        class BuildRecord
        {
            private static IUnityContainer _container;
            private static IRecordEnumPropertyParser[] _enumPropertyParsers;
            private static ITimingAllowanceParser _timingAllowanceParser;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _container = CifParserIocContainerBuilder.Build();
                _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
                _timingAllowanceParser = _container.Resolve<ITimingAllowanceParser>();
            }

            [Test]
            public void returns_expected_result_arrival_and_departure()
            {
                var recordParser = new IntermediateLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);

                string record = "LIMELKSHM 1307H1308      13081308         T                                     ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new IntermediateLocationRecord
                {
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

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_pass()
            {
                var recordParser = new IntermediateLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);

                string record = "LIBRDFDJN           1314 00000000                                               ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new IntermediateLocationRecord
                {
                    Tiploc = "BRDFDJN",
                    Pass = "1314",
                    OrderTime = "1314",
                    LocationActivityString = "            ",
                    PublicArrival = "0000",
                    PublicDeparture = "0000",
                    WorkingDeparture = string.Empty,
                    WorkingArrival = string.Empty
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}