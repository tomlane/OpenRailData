using System;
using Moq;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TCifScheduleManager
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var scheduleReaderMock = new Mock<IScheduleReader>();
            var scheduleParserMock = new Mock<IScheduleParser>();
            var scheduleRecordMergerMock = new Mock<IScheduleRecordMerger>();

            Assert.Throws<ArgumentNullException>(() => new CifScheduleManager(null, scheduleParserMock.Object, scheduleRecordMergerMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifScheduleManager(scheduleReaderMock.Object, null, scheduleRecordMergerMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifScheduleManager(scheduleReaderMock.Object, scheduleParserMock.Object, null));
        }

        [TestFixture]
        class ParseScheduleEntites
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var scheduleReaderMock = new Mock<IScheduleReader>();
                var scheduleParserMock = new Mock<IScheduleParser>();
                var scheduleRecordMergerMock = new Mock<IScheduleRecordMerger>();
                
                var scheduleManager = new CifScheduleManager(scheduleReaderMock.Object, scheduleParserMock.Object, scheduleRecordMergerMock.Object);

                Assert.Throws<ArgumentNullException>(() => scheduleManager.ParseScheduleRecords(null));
            }
        }
    }
}