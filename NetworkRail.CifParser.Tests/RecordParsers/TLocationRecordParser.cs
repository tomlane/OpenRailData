using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TLocationRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new LocationRecordParser(null));
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
            public void returns_expected_result_from_origin_location_record()
            {
                var recordBuilder = new LocationRecordParser(_parserContainer);

                string record = "LOSDON    1242 12422         TB                                                 ";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new LocationRecord
                {
                    RecordIdentity = CifRecordType.Location,
                    LocationType = LocationType.Originating,
                    Tiploc = "SDON",
                    Departure = new TimeSpan(0, 12, 42, 0),
                    PublicDeparture = new TimeSpan(0, 12, 42, 0),
                    Platform = "2",
                    LocationActivity = LocationActivity.TB,
                    LocationActivityString = "TB          ",
                    OrderTime = new TimeSpan(0, 12, 42, 0),
                    
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_from_intermediate_location_arrival_and_departure()
            {
                var recordBuilder = new LocationRecordParser(_parserContainer);

                string record = "LIMELKSHM 1307H1308      13081308         T                                     ";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new LocationRecord
                {
                    RecordIdentity = CifRecordType.Location,
                    LocationType = LocationType.Intermediate,
                    Tiploc = "MELKSHM",
                    Arrival = new TimeSpan(0, 13, 07, 30),
                    PublicArrival = new TimeSpan(0, 13, 08, 0),
                    Departure = new TimeSpan(0, 13, 08, 0),
                    PublicDeparture = new TimeSpan(0, 13, 08, 0),
                    LocationActivity = LocationActivity.T,
                    LocationActivityString = "T           ",
                    OrderTime = new TimeSpan(0, 13, 8, 0)
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_from_intermediate_location_pass()
            {
                var recordBuilder = new LocationRecordParser(_parserContainer);

                string record = "LIBRDFDJN           1314 00000000                                               ";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new LocationRecord
                {
                    RecordIdentity = CifRecordType.Location,
                    LocationType = LocationType.Intermediate,
                    Tiploc = "BRDFDJN",
                    Pass = new TimeSpan(0, 13, 14, 0),
                    OrderTime = new TimeSpan(0, 13, 14, 0),
                    LocationActivityString = "            ",
                    
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_from_terminating_location()
            {
                var recordBuilder = new LocationRecordParser(_parserContainer);

                string record = "LTWSTBRYW 1323 13253     TF                                                     ";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new LocationRecord
                {
                    RecordIdentity = CifRecordType.Location,
                    LocationType = LocationType.Terminating,
                    Tiploc = "WSTBRYW",
                    Arrival = new TimeSpan(0, 13, 23, 0),
                    PublicArrival = new TimeSpan(0, 13, 25, 0),
                    Platform = "3",
                    LocationActivity = LocationActivity.TF,
                    LocationActivityString = "TF          ",
                    OrderTime = new TimeSpan(0, 13, 23, 0)
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}