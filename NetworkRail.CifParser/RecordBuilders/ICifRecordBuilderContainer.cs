using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public interface ICifRecordBuilderContainer
    {
        ICifRecordBuilder<AssociationRecord> AssociationRecordBuilder { get; }
        ICifRecordBuilder<BasicScheduleExtraDetailsRecord> BasicScheduleExtraDetailsRecordBuilder { get; }
        ICifRecordBuilder<BasicScheduleRecord> BasicScheduleRecordBuilder { get; }
        ICifRecordBuilder<ChangesEnRouteRecord> ChangesEnRouteRecordBuilder { get; }
        ICifRecordBuilder<HeaderRecord> HeaderRecordBuilder { get; }
        ICifRecordBuilder<LocationRecord> LocationRecordBuilder { get; }
        ICifRecordBuilder<TiplocDeleteRecord> TiplocDeleteRecordBuilder { get; }
        ICifRecordBuilder<TiplocInsertAmendRecord> TiplocInsertAmendRecordBuilder { get; }     
    }
}