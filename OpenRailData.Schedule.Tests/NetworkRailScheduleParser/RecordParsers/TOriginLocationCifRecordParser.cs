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
    public class TOriginLocationCifRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();

            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(null, timingAllowanceParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(enumPropertyParsers, null));
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
                var recordParser = new OriginLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser);

                var record = "LOSDON    1242 12422         TB                                                 ";

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