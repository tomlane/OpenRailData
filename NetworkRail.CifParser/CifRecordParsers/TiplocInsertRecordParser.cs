using System;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Utils;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public class TiplocInsertRecordParser : ICifRecordParser
    {
        public string RecordKey { get; } = "TI";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            return new TiplocInsertRecord
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
        }
    }
}