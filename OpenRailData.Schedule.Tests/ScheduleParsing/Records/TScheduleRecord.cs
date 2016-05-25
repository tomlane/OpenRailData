using System;
using NUnit.Framework;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.Records
{
    [TestFixture]
    public class TScheduleRecord
    {
        [Test]
        public void throws_when_argument_is_null()
        {
            var basicScheduleRecord = new ScheduleRecord();

            Assert.Throws<ArgumentNullException>(() => basicScheduleRecord.MergeExtraScheduleDetails(null));
        }

        [Test]
        public void merges_extra_details_correctly()
        {
            var extraScheduleDetails = new BasicScheduleExtraDetailsRecord
            {
                AtsCode = "ATS",
                AtocCode = "ATOC",
                UicCode = "UIC",
                DataSource = "DATASOURCE",
                Rsid = "RSID"
            };

            var basicScheduleRecord = new ScheduleRecord();

            basicScheduleRecord.MergeExtraScheduleDetails(extraScheduleDetails);

            Assert.AreEqual(extraScheduleDetails.AtocCode, basicScheduleRecord.AtocCode);
            Assert.AreEqual(extraScheduleDetails.AtsCode, basicScheduleRecord.AtsCode);
            Assert.AreEqual(extraScheduleDetails.UicCode, basicScheduleRecord.UicCode);
            Assert.AreEqual(extraScheduleDetails.DataSource, basicScheduleRecord.DataSource);
            Assert.AreEqual(extraScheduleDetails.Rsid, basicScheduleRecord.Rsid);
        }
    }
}
