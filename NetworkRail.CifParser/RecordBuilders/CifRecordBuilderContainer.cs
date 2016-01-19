using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class CifRecordBuilderContainer : ICifRecordBuilderContainer
    {
        public ICifRecordBuilder<AssociationRecord> AssociationRecordBuilder { get; }
        public ICifRecordBuilder<BasicScheduleExtraDetailsRecord> BasicScheduleExtraDetailsRecordBuilder { get; }
        public ICifRecordBuilder<BasicScheduleRecord> BasicScheduleRecordBuilder { get; }
        public ICifRecordBuilder<ChangesEnRouteRecord> ChangesEnRouteRecordBuilder { get; }
        public ICifRecordBuilder<HeaderRecord> HeaderRecordBuilder { get; }
        public ICifRecordBuilder<LocationRecord> LocationRecordBuilder { get; }
        public ICifRecordBuilder<TiplocDeleteRecord> TiplocDeleteRecordBuilder { get; }
        public ICifRecordBuilder<TiplocInsertAmendRecord> TiplocInsertAmendRecordBuilder { get; }

        public CifRecordBuilderContainer(ICifRecordBuilder<AssociationRecord> associationRecordBuilder, 
            ICifRecordBuilder<BasicScheduleExtraDetailsRecord> basicScheduleExtraDetailsRecordBuilder, 
            ICifRecordBuilder<BasicScheduleRecord> basicScheduleRecordBuilder, 
            ICifRecordBuilder<ChangesEnRouteRecord> changesEnRouteRecordBuilder, 
            ICifRecordBuilder<HeaderRecord> headerRecordBuilder, 
            ICifRecordBuilder<LocationRecord> locationRecordBuilder, 
            ICifRecordBuilder<TiplocDeleteRecord> tiplocDeleteRecordBuilder, 
            ICifRecordBuilder<TiplocInsertAmendRecord> tiplocInsertAmendRecordBuilder)

            // inject an ienumerable of recordbuilders, create a dictionary with record type as key e.g. 'TD' (Tiploc Delete)
        {
            if (associationRecordBuilder == null)
                throw new ArgumentNullException(nameof(associationRecordBuilder));
            if (basicScheduleExtraDetailsRecordBuilder == null)
                throw new ArgumentNullException(nameof(basicScheduleExtraDetailsRecordBuilder));
            if (basicScheduleRecordBuilder == null)
                throw new ArgumentNullException(nameof(basicScheduleRecordBuilder));
            if (changesEnRouteRecordBuilder == null)
                throw new ArgumentNullException(nameof(changesEnRouteRecordBuilder));
            if (headerRecordBuilder == null)
                throw new ArgumentNullException(nameof(headerRecordBuilder));
            if (locationRecordBuilder == null)
                throw new ArgumentNullException(nameof(locationRecordBuilder));
            if (tiplocDeleteRecordBuilder == null)
                throw new ArgumentNullException(nameof(tiplocDeleteRecordBuilder));
            if (tiplocInsertAmendRecordBuilder == null)
                throw new ArgumentNullException(nameof(tiplocInsertAmendRecordBuilder));

            AssociationRecordBuilder = associationRecordBuilder;
            BasicScheduleExtraDetailsRecordBuilder = basicScheduleExtraDetailsRecordBuilder;
            BasicScheduleRecordBuilder = basicScheduleRecordBuilder;
            ChangesEnRouteRecordBuilder = changesEnRouteRecordBuilder;
            HeaderRecordBuilder = headerRecordBuilder;
            LocationRecordBuilder = locationRecordBuilder;
            TiplocDeleteRecordBuilder = tiplocDeleteRecordBuilder;
            TiplocInsertAmendRecordBuilder = tiplocInsertAmendRecordBuilder;
        }
    }
}