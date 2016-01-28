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
                var recordParser = new TerminatingLocationRecordParser(_enumPropertyParsers);

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