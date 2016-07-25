using OpenRailData.Schedule.Api.ResponseModels;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.Api.Presenters
{
    public static class AssociationRecordPresenter
    {
        public static AssociationSearchResponseModel PresentSearchResponse(AssociationRecord record)
        {
            return new AssociationSearchResponseModel
            {
                Location = record.Location,
                UniqueId = record.UniqueId,
                MainTrainUid = record.MainTrainUid,
                AssocTrainUid = record.AssocTrainUid
            };
        }
    }
}