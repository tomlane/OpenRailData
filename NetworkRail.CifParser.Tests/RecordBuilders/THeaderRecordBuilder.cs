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
    public class THeaderRecordBuilder
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
            var headerRecordParserContainerMock = new Mock<IHeaderRecordParserContainer>();

            Assert.Throws<ArgumentNullException>(() => new HeaderRecordBuilder(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var headerRecordParserContainerMock = new Mock<IHeaderRecordParserContainer>();

                var builder = new HeaderRecordBuilder(headerRecordParserContainerMock.Object);

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void throws_when_mainframe_identity_is_invalid()
            {
                var headerRecordParserContainerMock = new Mock<IHeaderRecordParserContainer>();

                var builder = new HeaderRecordBuilder(headerRecordParserContainerMock.Object);

                string record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

                Assert.Throws<InvalidOperationException>(() => builder.BuildRecord(record));
            }

            [Test]
            public void returns_expected_result()
            {
                var headerRecordParserContainerMock = _container.Resolve<IHeaderRecordParserContainer>();

                var builder = new HeaderRecordBuilder(headerRecordParserContainerMock);

                string record = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";

                var result = builder.BuildRecord(record);

                var expectedResult = new HeaderRecord
                {
                    MainFrameIdentity = "TPS.UDFROC1.PD151230",
                    DateOfExtract = new DateTime(2015, 12, 30),
                    TimeOfExtract = new TimeSpan(0, 21, 16),
                    CurrentFileRef = "DFROC1E",
                    LastFileRef = "DFROC1D",
                    ExtractUpdateType = ExtractUpdateType.UpdateExtract,
                    CifSoftwareVersion = "A",
                    UserExtractStartDate = new DateTime(2015, 12, 30),
                    UserExtractEndDate = new DateTime(2016, 12, 29),
                    MainFrameUser = "DFROC1",
                    MainFrameExtractDate = new DateTime(2015, 12, 30)
                };

                Assert.AreEqual(expectedResult.MainFrameIdentity, result.MainFrameIdentity);
                Assert.AreEqual(expectedResult.DateOfExtract, result.DateOfExtract);
                Assert.AreEqual(expectedResult.TimeOfExtract, result.TimeOfExtract);
                Assert.AreEqual(expectedResult.CurrentFileRef, result.CurrentFileRef);
                Assert.AreEqual(expectedResult.LastFileRef, result.LastFileRef);
                Assert.AreEqual(expectedResult.ExtractUpdateType, result.ExtractUpdateType);
                Assert.AreEqual(expectedResult.CifSoftwareVersion, result.CifSoftwareVersion);
                Assert.AreEqual(expectedResult.UserExtractStartDate, result.UserExtractStartDate);
                Assert.AreEqual(expectedResult.UserExtractEndDate, result.UserExtractEndDate);
                Assert.AreEqual(expectedResult.MainFrameUser, result.MainFrameUser);
                Assert.AreEqual(expectedResult.MainFrameExtractDate, result.MainFrameExtractDate);
            }
        }
    }
}