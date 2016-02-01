﻿using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenRailData.Schedule.DependencyInjection;
using OpenRailData.Schedule.PropertyParsers.NetworkRail;
using OpenRailData.Schedule.RecordParsers.NetworkRail.CifRecordParsers;
using OpenRailData.Schedule.Records.NetworkRail;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.Tests.RecordParsers.NetworkRail.CifRecordParsers
{
    [TestFixture]
    public class TChangesEnRouteCifRecordParser
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
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteCifRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_string_is_invalid()
            {
                var recordParser = new ChangesEnRouteCifRecordParser(_enumPropertyParsers);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new ChangesEnRouteCifRecordParser(_enumPropertyParsers);

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
                    PowerType = PowerType.DMU,
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