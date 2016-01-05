using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TChangesEnRouteRecordBuilder
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var changesEnRouteRecordParserContainer = new Mock<IChangesEnRouteRecordParserContainer>();

            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteRecordBuilder(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_string_is_invalid()
            {
                var changesEnRouteRecordParserContainer = new Mock<IChangesEnRouteRecordParserContainer>();

                var builder = new ChangesEnRouteRecordBuilder(changesEnRouteRecordParserContainer.Object);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var changesEnRouteRecordParserContainer = new Mock<IChangesEnRouteRecordParserContainer>();

                var builder = new ChangesEnRouteRecordBuilder(changesEnRouteRecordParserContainer.Object);

                string record = "CRHULL    XX1J22    111808920 DMUS   075      S S                               ";

                var result = builder.BuildRecord(record);

                var expectedResult = new ChangesEnRouteRecord
                {
                    Tiploc = "HULL",
                    TiplocSuffix = string.Empty,
                    Category = "XX",
                    TrainIdentity = "1J22",
                    HeadCode = string.Empty,
                    CourseIndicator = "1",
                    ServiceCode = "11808920",
                    PortionId = string.Empty,
                    PowerType = "DMU",
                    TimingLoad = "S",
                    Speed = "075",
                    OperatingCharacteristics = string.Empty,
                    SeatingClass = SeatingClass.StandardClassOnly,
                    Sleepers = SleeperDetails.NotAvailable,
                    Reservations = ReservationDetails.PossibleFromAnyStation,
                    ConnectionIndicator = string.Empty,
                    CateringCode = string.Empty,
                    ServiceBranding = string.Empty,
                    UicCode = string.Empty,
                    Rsid = string.Empty
                };

                Assert.AreEqual(expectedResult.Tiploc, result.Tiploc);
                Assert.AreEqual(expectedResult.TiplocSuffix, result.TiplocSuffix);
                Assert.AreEqual(expectedResult.Category, result.Category);
                Assert.AreEqual(expectedResult.TrainIdentity, result.TrainIdentity);
                Assert.AreEqual(expectedResult.HeadCode, result.HeadCode);
                Assert.AreEqual(expectedResult.CourseIndicator, result.CourseIndicator);
                Assert.AreEqual(expectedResult.ServiceCode, result.ServiceCode);
                Assert.AreEqual(expectedResult.PortionId, result.PortionId);
                Assert.AreEqual(expectedResult.PowerType, result.PowerType);
                Assert.AreEqual(expectedResult.TimingLoad, result.TimingLoad);
                Assert.AreEqual(expectedResult.Speed, result.Speed);
                Assert.AreEqual(expectedResult.OperatingCharacteristics, result.OperatingCharacteristics);
                Assert.AreEqual(expectedResult.SeatingClass, result.SeatingClass);
                Assert.AreEqual(expectedResult.Sleepers, result.Sleepers);
                Assert.AreEqual(expectedResult.Reservations, result.Reservations);
                Assert.AreEqual(expectedResult.ConnectionIndicator, result.ConnectionIndicator);
                Assert.AreEqual(expectedResult.CateringCode, result.CateringCode);
                Assert.AreEqual(expectedResult.ServiceBranding, result.ServiceBranding);
                Assert.AreEqual(expectedResult.UicCode, result.UicCode);
                Assert.AreEqual(expectedResult.Rsid, result.Rsid);
            }
        }
    }
}