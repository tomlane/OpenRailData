using OpenRailData.Schedule.Api.ResponseModels;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.Api.Presenters
{
    public static class TiplocRecordPresenter
    {
        public static TiplocRecordResponseModel PresentTiplocRecord(TiplocRecord record)
        {
            return new TiplocRecordResponseModel
            {
                LocationName = record.LocationName,
                TiplocCode = record.TiplocCode,
                CrsCode = record.CrsCode
            };
        }
    }
}