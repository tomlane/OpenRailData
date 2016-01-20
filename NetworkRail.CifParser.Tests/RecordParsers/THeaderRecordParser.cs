using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class THeaderRecordParser
    {
        private static IUnityContainer _container;
        private static IHeaderRecordParserContainer _parserContainer;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _parserContainer = _container.Resolve<IHeaderRecordParserContainer>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new HeaderRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new HeaderRecordParser(_parserContainer);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void throws_when_mainframe_identity_is_invalid()
            {
                var builder = new HeaderRecordParser(_parserContainer);

                string record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

                Assert.Throws<InvalidOperationException>(() => builder.BuildRecord(record));
            }

            [Test]
            public void returns_expected_result()
            {
                var builder = new HeaderRecordParser(_parserContainer);

                string record = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";

                var result = builder.BuildRecord(record);

                var expectedResult = new HeaderRecord
                {
                    RecordIdentity = CifRecordType.Header,
                    MainFrameIdentity = "TPS.UDFROC1.PD151230",
                    DateOfExtract = new DateTime(2015, 12, 30),
                    TimeOfExtract = new TimeSpan(21, 16, 0),
                    CurrentFileRef = "DFROC1E",
                    LastFileRef = "DFROC1D",
                    ExtractUpdateType = ExtractUpdateType.UpdateExtract,
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