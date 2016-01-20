using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public interface ICifRecordBuilderContainer
    {
        ICifRecordParser<AssociationRecord> AssociationRecordParser { get; }
        ICifRecordParser<BasicScheduleExtraDetailsRecord> BasicScheduleExtraDetailsRecordParser { get; }
        ICifRecordParser<BasicScheduleRecord> BasicScheduleRecordParser { get; }
        ICifRecordParser<ChangesEnRouteRecord> ChangesEnRouteRecordParser { get; }
        ICifRecordParser<HeaderRecord> HeaderRecordParser { get; }
        ICifRecordParser<LocationRecord> LocationRecordParser { get; }
        ICifRecordParser<TiplocDeleteRecord> TiplocDeleteRecordParser { get; }
        ICifRecordParser<TiplocInsertAmendRecord> TiplocInsertAmendRecordParser { get; }     
    }
}