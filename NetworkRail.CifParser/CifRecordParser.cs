using System;
using NetworkRail.CifParser.Entities;

namespace NetworkRail.CifParser
{
    public class CifRecordParser : ICifRecordParser
    {
        public ICifRecord ParseRecord(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentNullException(nameof(record));

            string recordType = record.Substring(0, 2);

            ICifRecord result = null;

            switch (recordType)
            {
                case "HD":
                    result = new HeaderRecord(record);
                    break;
                case "TI":
                    result = new TiplocInsertAmendRecord(record);
                    break;
                case "TA":
                    result = new TiplocInsertAmendRecord(record);
                    break;
                case "AA":
                    result = new AssociationRecord(record);
                    break;
                case "BS":
                    result = new BasicScheduleRecord(record);
                    break;
                case "BX":
                    result = new BasicScheduleExtraDetailsRecord(record);
                    break;
                case "LO":
                    result = new LocationRecord(record);
                    break;
                case "LI":
                    result = new LocationRecord(record);
                    break;
                case "CR":
                    result = new ChangesEnRouteRecord(record);
                    break;
                case "LT":
                    result = new LocationRecord(record);
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