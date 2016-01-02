using System;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class THeaderRecordBuilder
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new HeaderRecordBuilder();

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void throws_when_mainframe_identity_is_invalid()
            {
                var builder = new HeaderRecordBuilder();

                string record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

                Assert.Throws<InvalidOperationException>(() => builder.BuildRecord(record));
            }

            [Test]
            public void returns_expected_result()
            {
                var builder = new HeaderRecordBuilder();

                string record = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";

                var result = builder.BuildRecord(record);

                var expectedResult = new HeaderRecord
                {
                    MainFrameId = "TPS.UDFROC1.PD151230",
                    DateOfExtract = "301215",
                    TimeOfExtract = "2116",
                    CurrentFileRef = "DFROC1E",
                    LastFileRef = "DFROC1D",
                    UpdateType = "U",
                    CifSoftwareVersion = "A",
                    UserExtractStartDate = "301215",
                    UserExtractEndDate = "291216",
                    MainFrameUser = "DFROC1",
                    MainFrameExtractDate = "151230"
                };

                Assert.AreEqual(expectedResult.MainFrameId, result.MainFrameId);
                Assert.AreEqual(expectedResult.DateOfExtract, result.DateOfExtract);
                Assert.AreEqual(expectedResult.TimeOfExtract, result.TimeOfExtract);
                Assert.AreEqual(expectedResult.CurrentFileRef, result.CurrentFileRef);
                Assert.AreEqual(expectedResult.LastFileRef, result.LastFileRef);
                Assert.AreEqual(expectedResult.UpdateType, result.UpdateType);
                Assert.AreEqual(expectedResult.CifSoftwareVersion, result.CifSoftwareVersion);
                Assert.AreEqual(expectedResult.UserExtractStartDate, result.UserExtractStartDate);
                Assert.AreEqual(expectedResult.UserExtractEndDate, result.UserExtractEndDate);
                Assert.AreEqual(expectedResult.MainFrameUser, result.MainFrameUser);
                Assert.AreEqual(expectedResult.MainFrameExtractDate, result.MainFrameExtractDate);
            }
        }
    }
}