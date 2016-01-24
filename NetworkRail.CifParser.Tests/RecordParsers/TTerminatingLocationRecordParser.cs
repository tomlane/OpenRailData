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
    public class TTerminatingLocationRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TerminatingLocationRecordParser(null));
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
                var recordParser = new TerminatingLocationRecordParser(_parserContainer);

                string record = "LTWSTBRYW 1323 13253     TF                                                     ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TerminatingLocationRecord
                {
                    Tiploc = "WSTBRYW",
                    WorkingArrival = new TimeSpan(0, 13, 23, 0),
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