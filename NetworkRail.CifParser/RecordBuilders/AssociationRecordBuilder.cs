using System;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class AssociationRecordBuilder : ICifRecordBuilder<AssociationRecord>
    {
        public AssociationRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            AssociationRecord record = new AssociationRecord
            {
                TransactionType = recordString.Substring(2, 1),
                MainTrainUid = recordString.Substring(3, 6),
                AssocTrainUid = recordString.Substring(9, 6),
                DateFrom = recordString.Substring(15, 6),
                DateTo = recordString.Substring(21, 6).Trim(),
                Category = recordString.Substring(34, 2).Trim(),
                DateIndicator = recordString.Substring(36, 1).Trim(),
                Location = recordString.Substring(37, 7).Trim(),
                BaseLocationSuffix = recordString.Substring(44, 1).Trim(),
                AssocLocationSuffix = recordString.Substring(45, 1).Trim(),
                DiagramType = recordString.Substring(46, 1).Trim(),
                StpIndicator = recordString.Substring(79, 1).Trim()
            };

            if (recordString.Substring(27, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Monday;
            if (recordString.Substring(28, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Tuesday;
            if (recordString.Substring(29, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Wednesday;
            if (recordString.Substring(30, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Thursday;
            if (recordString.Substring(31, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Friday;
            if (recordString.Substring(32, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Saturday;
            if (recordString.Substring(33, 1).Trim() == "1")
                record.AssocDays = record.AssocDays | Days.Sunday;

            return record;
        }
    }
}