using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TBasicScheduleRecordBuilder
    {
        private static IUnityContainer _container;
        private static IBasicScheduleRecordParserContainer _parserContainer;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _parserContainer = _container.Resolve<IBasicScheduleRecordParserContainer>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new BasicScheduleRecordParser(_parserContainer);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_permanent_record()
            {
                var builder = new BasicScheduleRecordParser(_parserContainer);

                string record = "BSRY802011512141601011111100 PXX1A521780121702001 E  410 125EP    B R CM       P";

                var result = builder.BuildRecord(record);

                var expectedResult = new BasicScheduleRecord
                {
                    RecordIdentity = CifRecordType.BasicSchedule,
                    BankHolidayRunning = BankHolidayRunning.RunsOnBankHoliday,
                    TransactionType = TransactionType.Revise,
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
                    SeatingClass = SeatingClass.FirstAndStandardClass,
                    Sleepers = SleeperDetails.NotAvailable,
                    Reservations = ReservationDetails.Recommended,
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