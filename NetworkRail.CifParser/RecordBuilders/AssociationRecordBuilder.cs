using System;
using NetworkRail.CifParser.Records;

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
                TransactionType = recordString.Substring(2, 1)
            };


            record.MainTrainUid = recordString.Substring(3, 6);
            record.AssocTrainUid = recordString.Substring(9, 6);

            record.DateFrom = recordString.Substring(15, 6);
            record.DateTo = recordString.Substring(21, 6);

            record.AssocMonday = recordString.Substring(27, 1);
            record.AssocTuesday = recordString.Substring(28, 1);
            record.AssocWednesday = recordString.Substring(29, 1);
            record.AssocThursday = recordString.Substring(30, 1);
            record.AssocFriday = recordString.Substring(31, 1);
            record.AssocSaturday = recordString.Substring(32, 1);
            record.AssocSunday = recordString.Substring(33, 1);

            record.Category = recordString.Substring(34, 2);
            record.DateIndicator = recordString.Substring(36, 1);

            record.Location = recordString.Substring(37, 7);

            record.BaseLocationSuffix = recordString.Substring(44, 1);
            record.AssocLocationSuffix = recordString.Substring(45, 1);

            record.DiagramType = recordString.Substring(46, 1);

            record.StpIndicator = recordString.Substring(79, 1);


            record.DateTo = record.DateTo.Trim();

            if (record.StpIndicator == "C" || record.TransactionType == "D")
            {
                if (record.AssocMonday == "0" || record.AssocMonday == " ")
                    record.AssocMonday = record.AssocMonday.Trim();

                if (record.AssocTuesday == "0" || record.AssocTuesday == " ")
                    record.AssocTuesday = record.AssocTuesday.Trim();

                if (record.AssocWednesday == "0" || record.AssocWednesday == " ")
                    record.AssocWednesday = record.AssocWednesday.Trim();

                if (record.AssocThursday == "0" || record.AssocThursday == " ")
                    record.AssocThursday = record.AssocThursday.Trim();

                if (record.AssocFriday == "0" || record.AssocFriday == " ")
                    record.AssocFriday = record.AssocFriday.Trim();

                if (record.AssocSaturday == "0" || record.AssocSaturday == " ")
                    record.AssocSaturday = record.AssocSaturday.Trim();

                if (record.AssocSunday == "0" || record.AssocSunday == " ")
                    record.AssocSunday = record.AssocSunday.Trim();
            }

            record.Category = record.Category.Trim();
            record.DateIndicator = record.DateIndicator.Trim();
            record.Location = record.Location.Trim();
            record.BaseLocationSuffix = record.BaseLocationSuffix.Trim();
            record.AssocLocationSuffix = record.AssocLocationSuffix.Trim();
            record.AssocType = record.AssocType.Trim();
            record.DiagramType = record.DiagramType.Trim();
            record.StpIndicator = record.StpIndicator.Trim();

            return record;
        }
    }
}