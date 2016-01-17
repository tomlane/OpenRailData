using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TBasicScheduleRecordBuilder
    {
        private static IUnityContainer _container;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var basicScheduleRecordParserContainer = new Mock<IBasicScheduleRecordParserContainer>();

            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordBuilder(null));
            
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var basicScheduleRecordParserContainer = new Mock<IBasicScheduleRecordParserContainer>();

                var builder = new BasicScheduleRecordBuilder(basicScheduleRecordParserContainer.Object);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_permanent_record()
            {
                var basicScheduleRecordParserContainer = _container.Resolve<IBasicScheduleRecordParserContainer>();
                
                var builder = new BasicScheduleRecordBuilder(basicScheduleRecordParserContainer);

                string record = "BSRY802011512141601011111100 PXX1A521780121702001 E  410 125EP    B R CM       P";

                var result = builder.BuildRecord(record);

                var expectedResult = new BasicScheduleRecord
                {
                    RecordIdentity = CifRecordType.BasicSchedule,
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
                    StpIndicator = StpIndicator.P
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TransactionType, result.TransactionType);
                Assert.AreEqual(expectedResult.TrainUid, result.TrainUid);
                Assert.AreEqual(expectedResult.DateRunsFrom, result.DateRunsFrom);
                Assert.AreEqual(expectedResult.DateRunsTo, result.DateRunsTo);
                Assert.AreEqual(expectedResult.RunningDays, result.RunningDays);
                Assert.AreEqual(expectedResult.TrainStatus, result.TrainStatus);
                Assert.AreEqual(expectedResult.TrainCategory, result.TrainCategory);
                Assert.AreEqual(expectedResult.TrainIdentity, result.TrainIdentity);
                Assert.AreEqual(expectedResult.HeadCode, result.HeadCode);
                Assert.AreEqual(expectedResult.CourseIndicator, result.CourseIndicator);
                Assert.AreEqual(expectedResult.TrainServiceCode, result.TrainServiceCode);
                Assert.AreEqual(expectedResult.PortionId, result.PortionId);
                Assert.AreEqual(expectedResult.PowerType, result.PowerType);
                Assert.AreEqual(expectedResult.TimingLoad, result.TimingLoad);
                Assert.AreEqual(expectedResult.Speed, result.Speed);
                Assert.AreEqual(expectedResult.OperatingCharacteristicsString, result.OperatingCharacteristicsString);
                Assert.AreEqual(expectedResult.OperatingCharacteristics, result.OperatingCharacteristics);
                Assert.AreEqual(expectedResult.SeatingClass, result.SeatingClass);
                Assert.AreEqual(expectedResult.Sleepers, result.Sleepers);
                Assert.AreEqual(expectedResult.Reservations, result.Reservations);
                Assert.AreEqual(expectedResult.ConnectionIndicator, result.ConnectionIndicator);
                Assert.AreEqual(expectedResult.CateringCode, result.CateringCode);
                Assert.AreEqual(expectedResult.ServiceBranding, result.ServiceBranding);
                Assert.AreEqual(expectedResult.StpIndicator, result.StpIndicator);
            }
        }
    }
}