using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Utils;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class TiplocInsertAmendRecordBuilder : ICifRecordBuilder<TiplocInsertAmendRecord>
    {
        public TiplocInsertAmendRecord BuildRecord(string recordString)
        {
            TiplocInsertAmendRecord record = new TiplocInsertAmendRecord
            {
                Nlc = recordString.Substring(11, 6),
                TpsDescription = recordString.Substring(18, 26),
                Stanox = recordString.Substring(44, 5),
                Crs = recordString.Substring(53, 3),
                CapriDescription = recordString.Substring(56, 16)
            };

            string recordType = recordString.Substring(0, 2);

            if (recordType == "TI")
            {
                record.RecordType = "I";
                record.OldTiploc = string.Empty;
                record.TiplocCode = recordString.Substring(2, 7);
            }
            else if (recordType == "TA")
            {
                record.RecordType = "A";
                string newTiploc = recordString.Substring(72, 7).Trim();

                if (newTiploc == string.Empty)
                {
                    record.TiplocCode = recordString.Substring(2, 7);
                    record.OldTiploc = string.Empty;
                }
                else
                {
                    record.OldTiploc = recordString.Substring(2, 7);
                    record.TiplocCode = newTiploc;
                }
            }
            else
            {
                record.OldTiploc = string.Empty;
                record.TiplocCode = recordString.Substring(2, 7);
            }

            record.Nlc = record.Nlc.Trim();
            record.Crs = record.Crs.Trim();
            record.TpsDescription = record.TpsDescription.Trim();
            record.CapriDescription = record.CapriDescription.Trim();
            record.TiplocCode = record.TiplocCode.Trim();
            record.OldTiploc = record.OldTiploc.Trim();

            record.TpsDescription = record.TpsDescription.LocationCasing();
            record.CapriDescription = record.CapriDescription.LocationCasing();

            return record;
        }
    }
}