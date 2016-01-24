using System;
using System.IO;
using System.Linq;
using System.Text;
using Moq;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TCifScheduleManager
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new CifScheduleManager(null));
        }

        [TestFixture]
        class ParseScheduleEntites
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var scheduleManager = new CifScheduleManager(new ICifRecordParser[0]);

                Assert.Throws<ArgumentNullException>(() => scheduleManager.ParseScheduleEntites(null));
            }

            [Test]
            public void throws_when_record_length_is_not_80()
            {
                const string shortRecord = "blah not 80";

                var array = Encoding.ASCII.GetBytes(shortRecord);

                var stream = new MemoryStream(array);

                var scheduleManager = new CifScheduleManager(new ICifRecordParser[0]);

                Assert.Throws<ArgumentOutOfRangeException>(() => scheduleManager.ParseScheduleEntites(stream));
            }

            [Test]
            public void returns_end_of_file_record_correctly()
            {
                const string endOfFileRecord = "ZZ                                                                              ";

                var array = Encoding.ASCII.GetBytes(endOfFileRecord);

                var stream = new MemoryStream(array);

                var scheduleManager = new CifScheduleManager(new ICifRecordParser[0]);

                var result = scheduleManager.ParseScheduleEntites(stream);

                Assert.AreEqual(1, result.Count);
                Assert.IsInstanceOf<EndOfFileRecord>(result.First());
            }

            [Test]
            public void throws_when_no_parser_is_found_for_record_type()
            {
                const string unknownRecord = "XY                                                                              ";

                var array = Encoding.ASCII.GetBytes(unknownRecord);

                var stream = new MemoryStream(array);

                var scheduleManager = new CifScheduleManager(new ICifRecordParser[0]);

                Assert.Throws<ArgumentException>(() => scheduleManager.ParseScheduleEntites(stream));
            }

            [Test]
            public void returns_list_of_records_when_records_are_valid()
            {
                var recordParserMock = new Mock<ICifRecordParser>();

                recordParserMock.Setup(m => m.ParseRecord(It.IsAny<string>())).Returns(new BasicScheduleRecord());
                recordParserMock.SetupGet(m => m.RecordKey).Returns("BS");

                const string scheduleRecord = "BSNH635271512141601011111100            1                                      C";

                var array = Encoding.ASCII.GetBytes(scheduleRecord);

                var stream = new MemoryStream(array);

                var scheduleManager = new CifScheduleManager(new[]
                {
                    recordParserMock.Object
                });

                var result = scheduleManager.ParseScheduleEntites(stream);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(CifRecordType.BasicSchedule, result.First().RecordIdentity);
            }
        }
    }
}