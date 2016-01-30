using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TChangesEnRouteRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
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
                var recordParser = new ChangesEnRouteRecordParser(_enumPropertyParsers);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new ChangesEnRouteRecordParser(_enumPropertyParsers);

                string record = "CRHULL    XX1J22    111808920 DMUS   075      S S                               ";

                var result = recordParser.ParseRecord(record);

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
                    Speed = 075,
                    OperatingCharacteristics = string.Empty,
                    SeatingClass = SeatingClass.S,
                    Sleepers = SleeperDetails.NotAvailable,
                    Reservations = ReservationDetails.S,
                    ConnectionIndicator = string.Empty,
                    CateringCode = 0,
                    ServiceBranding = ServiceBranding.None,
                    UicCode = string.Empty,
                    Rsid = string.Empty
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}