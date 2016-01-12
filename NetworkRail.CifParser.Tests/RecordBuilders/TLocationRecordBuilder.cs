using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TLocationRecordBuilder
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var locationRecordParserContainerMock = new Mock<ILocationRecordParserContainer>();

            Assert.Throws<ArgumentNullException>(() => new LocationRecordBuilder(null));
        }

        [TestFixture]
        class BuildRecord
        {
            private static IUnityContainer _container;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _container = CifParserIocContainerBuilder.Build();
            }

            [Test]
            public void returns_expected_result_from_origin_location_record()
            {
                var locationRecordParserContainer = _container.Resolve<ILocationRecordParserContainer>();

                var recordBuilder = new LocationRecordBuilder(locationRecordParserContainer);

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
                    LocationActivity = LocationActivity.TB
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.LocationType, result.LocationType);
                Assert.AreEqual(expectedResult.Tiploc, result.Tiploc);
                Assert.AreEqual(expectedResult.Departure, result.Departure);
                Assert.AreEqual(expectedResult.PublicDeparture, result.PublicDeparture);
                Assert.AreEqual(expectedResult.Platform, result.Platform);
                Assert.AreEqual(expectedResult.LocationActivity, result.LocationActivity);
            }

            [Test]
            public void returns_expected_result_from_intermediate_location_arrival_and_departure()
            {
                var locationRecordParserContainer = _container.Resolve<ILocationRecordParserContainer>();

                var recordBuilder = new LocationRecordBuilder(locationRecordParserContainer);

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
                    LocationActivity = LocationActivity.T
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.LocationType, result.LocationType);
                Assert.AreEqual(expectedResult.Tiploc, result.Tiploc);
                Assert.AreEqual(expectedResult.Departure, result.Departure);
                Assert.AreEqual(expectedResult.PublicDeparture, result.PublicDeparture);
                Assert.AreEqual(expectedResult.Arrival, result.Arrival);
                Assert.AreEqual(expectedResult.PublicArrival, result.PublicArrival);
                Assert.AreEqual(expectedResult.LocationActivity, result.LocationActivity);
            }

            [Test]
            public void returns_expected_result_from_intermediate_location_pass()
            {
                var locationRecordParserContainer = _container.Resolve<ILocationRecordParserContainer>();

                var recordBuilder = new LocationRecordBuilder(locationRecordParserContainer);

                string record = "LIBRDFDJN           1314 00000000                                               ";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new LocationRecord
                {
                    RecordIdentity = CifRecordType.Location,
                    LocationType = LocationType.Intermediate,
                    Tiploc = "BRDFDJN",
                    Pass = new TimeSpan(0, 13, 14, 0)
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.LocationType, result.LocationType);
                Assert.AreEqual(expectedResult.Tiploc, result.Tiploc);
                Assert.AreEqual(expectedResult.Pass, result.Pass);
            }

            [Test]
            public void returns_expected_result_from_terminating_location()
            {
                var locationRecordParserContainer = _container.Resolve<ILocationRecordParserContainer>();

                var recordBuilder = new LocationRecordBuilder(locationRecordParserContainer);

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
                    LocationActivity = LocationActivity.TF
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.LocationType, result.LocationType);
                Assert.AreEqual(expectedResult.Tiploc, result.Tiploc);
                Assert.AreEqual(expectedResult.Arrival, result.Arrival);
                Assert.AreEqual(expectedResult.PublicArrival, result.PublicArrival);
                Assert.AreEqual(expectedResult.Platform, result.Platform);
                Assert.AreEqual(expectedResult.LocationActivity, result.LocationActivity);
                Assert.AreEqual(expectedResult.Location, result.Location);
            }
        }
    }
}