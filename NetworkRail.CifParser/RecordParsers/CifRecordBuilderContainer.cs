using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class CifRecordBuilderContainer : ICifRecordBuilderContainer
    {
        public ICifRecordParser<AssociationRecord> AssociationRecordParser { get; }
        public ICifRecordParser<BasicScheduleExtraDetailsRecord> BasicScheduleExtraDetailsRecordParser { get; }
        public ICifRecordParser<BasicScheduleRecord> BasicScheduleRecordParser { get; }
        public ICifRecordParser<ChangesEnRouteRecord> ChangesEnRouteRecordParser { get; }
        public ICifRecordParser<HeaderRecord> HeaderRecordParser { get; }
        public ICifRecordParser<LocationRecord> LocationRecordParser { get; }
        public ICifRecordParser<TiplocDeleteRecord> TiplocDeleteRecordParser { get; }
        public ICifRecordParser<TiplocInsertAmendRecord> TiplocInsertAmendRecordParser { get; }

        public CifRecordBuilderContainer(ICifRecordParser<AssociationRecord> associationRecordParser, 
            ICifRecordParser<BasicScheduleExtraDetailsRecord> basicScheduleExtraDetailsRecordParser, 
            ICifRecordParser<BasicScheduleRecord> basicScheduleRecordParser, 
            ICifRecordParser<ChangesEnRouteRecord> changesEnRouteRecordParser, 
            ICifRecordParser<HeaderRecord> headerRecordParser, 
            ICifRecordParser<LocationRecord> locationRecordParser, 
            ICifRecordParser<TiplocDeleteRecord> tiplocDeleteRecordParser, 
            ICifRecordParser<TiplocInsertAmendRecord> tiplocInsertAmendRecordParser)

            // inject an ienumerable of recordbuilders, create a dictionary with record type as key e.g. 'TD' (Tiploc Delete)
        {
            if (associationRecordParser == null)
                throw new ArgumentNullException(nameof(associationRecordParser));
            if (basicScheduleExtraDetailsRecordParser == null)
                throw new ArgumentNullException(nameof(basicScheduleExtraDetailsRecordParser));
            if (basicScheduleRecordParser == null)
                throw new ArgumentNullException(nameof(basicScheduleRecordParser));
            if (changesEnRouteRecordParser == null)
                throw new ArgumentNullException(nameof(changesEnRouteRecordParser));
            if (headerRecordParser == null)
                throw new ArgumentNullException(nameof(headerRecordParser));
            if (locationRecordParser == null)
                throw new ArgumentNullException(nameof(locationRecordParser));
            if (tiplocDeleteRecordParser == null)
                throw new ArgumentNullException(nameof(tiplocDeleteRecordParser));
            if (tiplocInsertAmendRecordParser == null)
                throw new ArgumentNullException(nameof(tiplocInsertAmendRecordParser));

            AssociationRecordParser = associationRecordParser;
            BasicScheduleExtraDetailsRecordParser = basicScheduleExtraDetailsRecordParser;
            BasicScheduleRecordParser = basicScheduleRecordParser;
            ChangesEnRouteRecordParser = changesEnRouteRecordParser;
            HeaderRecordParser = headerRecordParser;
            LocationRecordParser = locationRecordParser;
            TiplocDeleteRecordParser = tiplocDeleteRecordParser;
            TiplocInsertAmendRecordParser = tiplocInsertAmendRecordParser;
        }
    }
}