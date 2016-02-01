using System;
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
    public class TTerminatingLocationCifRecordParser
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TerminatingLocationCifRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            private static IUnityContainer _container;
            private static IRecordEnumPropertyParser[] _enumPropertyParsers;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _container = CifParserIocContainerBuilder.Build();
                _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            }
            
            [Test]
            public void returns_expected_result()
            {
                var recordParser = new TerminatingLocationCifRecordParser(_enumPropertyParsers);

                string record = "LTWSTBRYW 1323 13253     TF                                                     ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TerminatingLocationRecord
                {
                    Tiploc = "WSTBRYW",
                    WorkingArrival = "1323",
                    PublicArrival = "1325",
                    Platform = "3",
                    LocationActivity = LocationActivity.TF,
                    LocationActivityString = "TF          ",
                    OrderTime = "1323"
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}