using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TChangesEnRouteCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        [SetUp]
        public void Setup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private static ChangesEnRouteCifRecordParser BuildParser()
        {
            return new ChangesEnRouteCifRecordParser(_enumPropertyParsers);
        }

        [Test]
        public void returns_correct_property_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("CR", parser.RecordKey);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteCifRecordParser(null));
        }

        [Test]
        public void throws_when_argument_string_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "CRHULL    XX1J22    111808920 DMUS   075      S S                               ";
            var expectedResult = new ChangesEnRouteRecord
            {
                RecordIdentity = ScheduleRecordType.CR,
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

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}