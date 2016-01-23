using System;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Utils;

namespace NetworkRail.CifParser.RecordParsers
{
    public class TiplocAmendRecordParser : ICifRecordParser
    {
        public string RecordKey { get; } = "TA";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new TiplocAmendRecord
            {
                TiplocCode = recordString.Substring(2, 7).Trim(),
                CapitalsIdentification = recordString.Substring(9, 2).Trim(),
                Nalco = recordString.Substring(11, 6).Trim(),
                Nlc = recordString.Substring(17, 1).Trim(),
                TpsDescription = recordString.Substring(18, 26).Trim().LocationCasing(),
                Stanox = recordString.Substring(44, 5).Trim(),
                PoMcbCode = recordString.Substring(49, 4).Trim(),
                CrsCode = recordString.Substring(53, 3).Trim(),
                CapriDescription = recordString.Substring(56, 16).Trim().LocationCasing()
            };

            string newTiploc = recordString.Substring(72, 7).Trim();

            if (newTiploc == string.Empty)
                return record;

            record.OldTiploc = record.TiplocCode;
            record.TiplocCode = newTiploc;

            return record;
        }
    }
}