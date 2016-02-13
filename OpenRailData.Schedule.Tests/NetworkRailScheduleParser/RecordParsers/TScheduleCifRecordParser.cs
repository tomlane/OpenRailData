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
    public class TScheduleCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        [SetUp]
        public void Setup()
        {
            _container = CifParserIocContainerBuilder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        private ScheduleCifRecordParser BuildParser()
        {
            return new ScheduleCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(enumPropertyParsers, null));
            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(null, dateTimeParserMock.Object));
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = new ScheduleCifRecordParser(_enumPropertyParsers, _dateTimeParser);

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_expected_result_with_permanent_record()
        {
            var recordParser = new ScheduleCifRecordParser(_enumPropertyParsers, _dateTimeParser);
            var recordToParse = "BSRY802011512141601011111100 PXX1A521780121702001 E  410 125EP    B R CM       P";
            var expectedResult = new ScheduleRecord
            {
                RecordIdentity = ScheduleRecordType.BSR,
                BankHolidayRunning = BankHolidayRunning.R,
                TrainUid = "Y80201",
                DateRunsFrom = new DateTime(2015, 12, 14),
                DateRunsTo = new DateTime(2016, 1, 1),
                RunningDays = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday,
                TrainStatus = "P",
                TrainCategory = "XX",
                TrainIdentity = "1A52",
                HeadCode = "1780",
                CourseIndicator = "1",
                TrainServiceCode = "21702001",
                PortionId = string.Empty,
                PowerType = PowerType.E,
                TimingLoad = "410",
                Speed = 125,
                OperatingCharacteristicsString = "EP    ",
                OperatingCharacteristics = OperatingCharacteristics.E | OperatingCharacteristics.P,
                SeatingClass = SeatingClass.B,
                Sleepers = SleeperDetails.NotAvailable,
                Reservations = ReservationDetails.R,
                ConnectionIndicator = string.Empty,
                CateringCode = CateringCode.C | CateringCode.M,
                ServiceBranding = 0,
                StpIndicator = StpIndicator.P,
                UniqueId = "Y80201151214P",
                ServiceTypeFlags = ServiceTypeFlags.Passenger | ServiceTypeFlags.Train
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.AreEqual(expectedResult, result);
        }
    }
}