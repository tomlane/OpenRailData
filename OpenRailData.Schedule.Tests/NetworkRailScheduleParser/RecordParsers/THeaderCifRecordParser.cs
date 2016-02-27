using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class THeaderCifRecordParser
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

        private static HeaderCifRecordParser BuildParser()
        {
            return new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var datetimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(null, datetimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(enumPropertyParsers, null));
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("HD", parser.RecordKey);
        }

        [Test]
        public void throws_when_mainframe_identity_is_invalid()
        {
            var recordParser = BuildParser();

            var record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

            Assert.Throws<InvalidOperationException>(() => recordParser.ParseRecord(record));
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";
            var expectedResult = new HeaderRecord
            {
                RecordIdentity = ScheduleRecordType.HD,
                MainFrameIdentity = "TPS.UDFROC1.PD151230",
                DateOfExtract = new DateTime(2015, 12, 30),
                TimeOfExtract = "2116",
                CurrentFileRef = "DFROC1E",
                LastFileRef = "DFROC1D",
                ExtractUpdateType = ExtractUpdateType.U,
                CifSoftwareVersion = "A",
                UserExtractStartDate = new DateTime(2015, 12, 30),
                UserExtractEndDate = new DateTime(2016, 12, 29),
                MainFrameUser = "DFROC1",
                MainFrameExtractDate = new DateTime(2015, 12, 30)
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
