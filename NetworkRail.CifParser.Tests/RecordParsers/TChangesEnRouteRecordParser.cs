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
    public class TChangesEnRouteRecordParser
    {
        private static IUnityContainer _container;
        private static IChangesEnRouteRecordParserContainer _parserContainer;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _parserContainer = _container.Resolve<IChangesEnRouteRecordParserContainer>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_string_is_invalid()
            {
                var recordParser = new ChangesEnRouteRecordParser(_parserContainer);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new ChangesEnRouteRecordParser(_parserContainer);

                string record = "CRHULL    XX1J22    111808920 DMUS   075      S S                               ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new ChangesEnRouteRecord
                {
                    RecordIdentity = CifRecordType.ChangesEnRoute,
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
                    Speed = 075,
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

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}