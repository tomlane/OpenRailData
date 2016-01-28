﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TOriginLocationRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new OriginLocationRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new OriginLocationRecordParser(enumPropertyParsers, null));
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
            public void returns_expected_result()
            {
                var recordParser = new OriginLocationRecordParser(_enumPropertyParsers, _timingAllowanceParser);

                string record = "LOSDON    1242 12422         TB                                                 ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new OriginLocationRecord
                {
                    Tiploc = "SDON",
                    WorkingDeparture = "1242",
                    PublicDeparture = "1242",
                    Platform = "2",
                    LocationActivity = LocationActivity.TB,
                    LocationActivityString = "TB          ",
                    OrderTime = "1242"
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}