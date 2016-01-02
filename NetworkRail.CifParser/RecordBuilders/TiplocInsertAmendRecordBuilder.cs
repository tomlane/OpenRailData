using System;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Utils;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class TiplocInsertAmendRecordBuilder : ICifRecordBuilder<TiplocInsertAmendRecord>
    {
        public TiplocInsertAmendRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            TiplocInsertAmendRecord record = new TiplocInsertAmendRecord
            {
                TiplocCode = recordString.Substring(2, 7),
                CapitalsIdentification = recordString.Substring(9, 2),
                Nalco = recordString.Substring(11, 6),
                Nlc = recordString.Substring(17, 1),
                TpsDescription = recordString.Substring(18, 26),
                Stanox = recordString.Substring(44, 5),
                PoMcbCode = recordString.Substring(49, 4),
                CrsCode = recordString.Substring(53, 3),
                CapriDescription = recordString.Substring(56, 16)
            };

            string recordType = recordString.Substring(0, 2);

            if (recordType == "TI")
            {
                record.RecordType = "I";
            }
            else if (recordType == "TA")
            {
                record.RecordType = "A";

                string newTiploc = recordString.Substring(72, 7).Trim();
                
                if (newTiploc != string.Empty)
                {
                    record.OldTiploc = recordString.Substring(2, 7);
                    record.TiplocCode = newTiploc;
                }
            }

            record.TiplocCode = record.TiplocCode.Trim();
            record.Nalco = record.Nalco.Trim();
            record.Nlc = record.Nlc.Trim();
            record.CrsCode = record.CrsCode.Trim();
            record.TpsDescription = record.TpsDescription.Trim();
            record.PoMcbCode = record.PoMcbCode.Trim();
            record.CapriDescription = record.CapriDescription.Trim();
            record.TpsDescription = record.TpsDescription.LocationCasing();
            record.CapriDescription = record.CapriDescription.LocationCasing();

            record.OldTiploc = record.OldTiploc.Trim();

            return record;
        }
    }
}