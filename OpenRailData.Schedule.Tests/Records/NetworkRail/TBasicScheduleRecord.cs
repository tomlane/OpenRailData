using System;
using NUnit.Framework;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.Tests.Records.NetworkRail
{
    [TestFixture]
    public class TBasicScheduleRecord
    {
        [TestFixture]
        class MergeExtraScheduleDetails
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var basicScheduleRecord = new BasicScheduleRecord();

                Assert.Throws<ArgumentNullException>(() => basicScheduleRecord.MergeExtraScheduleDetails(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var extraScheduleDetails = new BasicScheduleExtraDetailsRecord
                {
                    AtsCode = "ATS",
                    AtocCode = "ATOC",
                    UicCode = "UIC",
                    DataSource = "DATASOURCE",
                    Rsid = "RSID"
                };

                var basicScheduleRecord = new BasicScheduleRecord();

                basicScheduleRecord.MergeExtraScheduleDetails(extraScheduleDetails);

                Assert.AreEqual(extraScheduleDetails.AtocCode, basicScheduleRecord.AtocCode);
                Assert.AreEqual(extraScheduleDetails.AtsCode, basicScheduleRecord.AtsCode);
                Assert.AreEqual(extraScheduleDetails.UicCode, basicScheduleRecord.UicCode);
                Assert.AreEqual(extraScheduleDetails.DataSource, basicScheduleRecord.DataSource);
                Assert.AreEqual(extraScheduleDetails.Rsid, basicScheduleRecord.Rsid);
            }
        }
    }
}