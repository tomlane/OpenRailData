using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
{
    [TestFixture]
    public class THeaderCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var datetimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(null, datetimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(enumPropertyParsers, null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void throws_when_mainframe_identity_is_invalid()
            {
                var recordParser = new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser);

                string record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

                Assert.Throws<InvalidOperationException>(() => recordParser.ParseRecord(record));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser);

                string record = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new HeaderRecord
                {
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

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}