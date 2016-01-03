using System;
using Moq;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TBasicScheduleRecordBuilder
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var operatingCharacteristicsParserMock = new Mock<IOperatingCharacteristicsParser>();

            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordBuilder(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var operatingCharacteristicsParserMock = new Mock<IOperatingCharacteristicsParser>();

                var builder = new BasicScheduleRecordBuilder(operatingCharacteristicsParserMock.Object);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_permanent_record()
            {
                var operatingCharacteristicsParserMock = new Mock<IOperatingCharacteristicsParser>();

                operatingCharacteristicsParserMock.Setup(m => m.ParseOperatingCharacteristics(It.IsAny<string>()))
                    .Returns(new OperatingCharacteristics() | OperatingCharacteristics.E | OperatingCharacteristics.P);

                var builder = new BasicScheduleRecordBuilder(operatingCharacteristicsParserMock.Object);

                string record = "BSRY802011512141601011111100 PXX1A521780121702001 E  410 125EP    B R CM       P";

                var result = builder.BuildRecord(record);

                var expectedResult = new BasicScheduleRecord
                {
                    TransactionType = "R",
                    TrainUid = "Y80201",
                    DateRunsFrom = "151214",
                    DateRunsTo = "160101",
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
                    Speed = "125",
                    OperatingCharacteristicsString = "EP    ",
                    OperatingCharacteristics = OperatingCharacteristics.E | OperatingCharacteristics.P,
                    SeatingClass = "B",
                    Sleepers = string.Empty,
                    Reservations = "R",
                    ConnectionIndicator = string.Empty,
                    CateringCode = "CM",
                    ServiceBranding = string.Empty,
                    StpIndicator = "P"
                };

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