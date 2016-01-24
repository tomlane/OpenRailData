using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TIntermediateLocationRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            private static IUnityContainer _container;
            private static ILocationRecordParserContainer _parserContainer;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _container = CifParserIocContainerBuilder.Build();
                _parserContainer = _container.Resolve<ILocationRecordParserContainer>();
            }

            [Test]
            public void returns_expected_result_arrival_and_departure()
            {
                var recordParser = new IntermediateLocationRecordParser(_parserContainer);

                string record = "LIMELKSHM 1307H1308      13081308         T                                     ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new IntermediateLocationRecord
                {
                    Tiploc = "MELKSHM",
                    WorkingArrival = new TimeSpan(0, 13, 07, 30),
                    PublicArrival = new TimeSpan(0, 13, 08, 0),
                    WorkingDeparture = new TimeSpan(0, 13, 08, 0),
                    PublicDeparture = new TimeSpan(0, 13, 08, 0),
                    LocationActivity = LocationActivity.T,
                    LocationActivityString = "T           ",
                    OrderTime = new TimeSpan(0, 13, 8, 0)
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_pass()
            {
                var recordParser = new IntermediateLocationRecordParser(_parserContainer);

                string record = "LIBRDFDJN           1314 00000000                                               ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new IntermediateLocationRecord
                {
                    Tiploc = "BRDFDJN",
                    Pass = new TimeSpan(0, 13, 14, 0),
                    OrderTime = new TimeSpan(0, 13, 14, 0),
                    LocationActivityString = "            "
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}