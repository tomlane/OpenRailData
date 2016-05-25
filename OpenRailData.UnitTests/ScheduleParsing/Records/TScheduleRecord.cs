using System;
using OpenRailData.Domain.ScheduleRecords;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.Records
{
    
    public class TScheduleRecord
    {
        [Fact]
        public void throws_when_argument_is_null()
        {
            var basicScheduleRecord = new ScheduleRecord();

            Assert.Throws<ArgumentNullException>(() => basicScheduleRecord.MergeExtraScheduleDetails(null));
        }

        [Fact]
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

            Assert.Equal(extraScheduleDetails.AtocCode, basicScheduleRecord.AtocCode);
            Assert.Equal(extraScheduleDetails.AtsCode, basicScheduleRecord.AtsCode);
            Assert.Equal(extraScheduleDetails.UicCode, basicScheduleRecord.UicCode);
            Assert.Equal(extraScheduleDetails.DataSource, basicScheduleRecord.DataSource);
            Assert.Equal(extraScheduleDetails.Rsid, basicScheduleRecord.Rsid);
        }
    }
}
