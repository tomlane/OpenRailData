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
    public class TBasicScheduleRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            _container = CifParserIocContainerBuilder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParser(enumPropertyParsers, null));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParser(null, dateTimeParserMock.Object));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new BasicScheduleRecordParser(_enumPropertyParsers, _dateTimeParser);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_permanent_record()
            {
                var recordParser = new BasicScheduleRecordParser(_enumPropertyParsers, _dateTimeParser);

                string record = "BSRY802011512141601011111100 PXX1A521780121702001 E  410 125EP    B R CM       P";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new BasicScheduleRecord
                {
                    BankHolidayRunning = BankHolidayRunning.R,
                    TransactionType = TransactionType.R,
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
                    PowerType = "E",
                    TimingLoad = "410",
                    Speed = 125,
                    OperatingCharacteristicsString = "EP    ",
                    OperatingCharacteristics = OperatingCharacteristics.E | OperatingCharacteristics.P,
                    SeatingClass = SeatingClass.B,
                    Sleepers = SleeperDetails.NotAvailable,
                    Reservations = ReservationDetails.R,
                    ConnectionIndicator = string.Empty,
                    CateringCode = "CM",
                    ServiceBranding = string.Empty,
                    StpIndicator = StpIndicator.P,
                    UniqueId = "Y80201151214P",
                    ServiceTypeFlags = ServiceTypeFlags.Passenger | ServiceTypeFlags.Train
                    
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}