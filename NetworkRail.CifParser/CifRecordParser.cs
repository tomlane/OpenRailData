using System;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifRecordParser : ICifRecordParser
    {
        private readonly ICifRecordBuilderContainer _cifRecordBuilderContainer;

        public CifRecordParser(ICifRecordBuilderContainer cifRecordBuilderContainer)
        {
            if (cifRecordBuilderContainer == null)
                throw new ArgumentNullException(nameof(cifRecordBuilderContainer));

            _cifRecordBuilderContainer = cifRecordBuilderContainer;
        }

        public ICifRecord ParseRecord(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentNullException(nameof(record));

            string recordType = record.Substring(0, 2);

            ICifRecord result = null;

            switch (recordType)
            {
                case "HD":
                    result = _cifRecordBuilderContainer.HeaderRecordBuilder.BuildRecord(record);
                    break;
                case "TI":
                    result = _cifRecordBuilderContainer.TiplocInsertAmendRecordBuilder.BuildRecord(record);
                    break;
                case "TA":
                    result = _cifRecordBuilderContainer.TiplocInsertAmendRecordBuilder.BuildRecord(record);
                    break;
                case "AA":
                    result = _cifRecordBuilderContainer.AssociationRecordBuilder.BuildRecord(record);
                    break;
                case "BS":
                    result = _cifRecordBuilderContainer.BasicScheduleRecordBuilder.BuildRecord(record);
                    break;
                case "BX":
                    result = _cifRecordBuilderContainer.BasicScheduleExtraDetailsRecordBuilder.BuildRecord(record);
                    break;
                case "LO":
                    result = _cifRecordBuilderContainer.LocationRecordBuilder.BuildRecord(record);
                    break;
                case "LI":
                    result = _cifRecordBuilderContainer.LocationRecordBuilder.BuildRecord(record);
                    break;
                case "CR":
                    result = _cifRecordBuilderContainer.ChangesEnRouteRecordBuilder.BuildRecord(record);
                    break;
                case "LT":
                    result = _cifRecordBuilderContainer.LocationRecordBuilder.BuildRecord(record); ;
                    break;
                case "ZZ":
                    break;
                default:
                    throw new NotImplementedException($"The following record type has not been implemented: {recordType}");
            }

            return result;
        }
    }
}