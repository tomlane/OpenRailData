﻿using System;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
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

            string recordType = recordString.Substring(0, 2);

            if (recordType == "TI")
            {
                record.RecordIdentity = CifRecordType.TiplocInsert;
                record.TiplocRecordType = TiplocRecordType.Insert;
            }
            else if (recordType == "TA")
            {
                record.RecordIdentity = CifRecordType.TiplocAmend;
                record.TiplocRecordType = TiplocRecordType.Amend;

                string newTiploc = recordString.Substring(72, 7).Trim();
                
                if (newTiploc != string.Empty)
                {
                    record.OldTiploc = recordString.Substring(2, 7).Trim();
                    record.TiplocCode = newTiploc;
                }
            }

            return record;
        }
    }
}