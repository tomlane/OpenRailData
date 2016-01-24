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
    public class TOriginLocationRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new OriginLocationRecordParser(null));
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
            public void returns_expected_result()
            {
                var recordParser = new OriginLocationRecordParser(_parserContainer);

                string record = "LOSDON    1242 12422         TB                                                 ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new OriginLocationRecord
                {
                    Tiploc = "SDON",
                    WorkingDeparture = new TimeSpan(0, 12, 42, 0),
                    PublicDeparture = new TimeSpan(0, 12, 42, 0),
                    Platform = "2",
                    LocationActivity = LocationActivity.TB,
                    LocationActivityString = "TB          ",
                    OrderTime = new TimeSpan(0, 12, 42, 0),
                    
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}