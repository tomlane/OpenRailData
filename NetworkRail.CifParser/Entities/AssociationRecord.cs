using System;

namespace NetworkRail.CifParser.Entities
{
    public class AssociationRecord : ICifRecord
    {
        public string TransactionType { get; } 
        public string MainTrainUid { get; } = string.Empty;
        public string AssocTrainUid { get; } = string.Empty;
        public string DateFrom { get; } = string.Empty;
        public string DateTo { get; } = string.Empty;
        public string AssocMonday { get; } = string.Empty;
        public string AssocTuesday { get; } = string.Empty;
        public string AssocWednesday { get; } = string.Empty;
        public string AssocThursday { get; } = string.Empty;
        public string AssocFriday { get; } = string.Empty;
        public string AssocSaturday { get; } = string.Empty;
        public string AssocSunday { get; } = string.Empty;
        public string Category { get; } = string.Empty;
        public string DateIndicator { get; } = string.Empty;
        public string Location { get; } = string.Empty;
        public string BaseLocationSuffix { get; } = string.Empty;
        public string AssocLocationSuffix { get; } = string.Empty;
        public string AssocType { get; } = string.Empty;
        public string StpIndicator { get; } = string.Empty;

        public AssociationRecord(string record)
        {
            TransactionType = record.Substring(2, 1);

            try
            {
                MainTrainUid = record.Substring(3, 6);
                AssocTrainUid = record.Substring(9, 6);

                DateFrom = record.Substring(15, 6);
                DateTo = record.Substring(21, 6);

                AssocMonday = record.Substring(27, 1);
                AssocTuesday = record.Substring(28, 1);
                AssocWednesday = record.Substring(29, 1);
                AssocThursday = record.Substring(30, 1);
                AssocFriday = record.Substring(31, 1);
                AssocSaturday = record.Substring(32, 1);
                AssocSunday = record.Substring(33, 1);

                Category = record.Substring(34, 1);

                DateIndicator = record.Substring(36, 1);

                Location = record.Substring(37, 7);
                BaseLocationSuffix = record.Substring(44, 1);
                AssocLocationSuffix = record.Substring(45, 1);

                AssocType = record.Substring(47, 1);

                StpIndicator = record.Substring(79, 1);
            }
            catch (ArgumentOutOfRangeException){}

            if (StpIndicator == "C" || TransactionType == "D")
            {
                if (AssocMonday == "0" || AssocMonday == " ")
                    AssocMonday = AssocMonday.Trim();

                if (AssocTuesday == "0" || AssocTuesday == " ")
                    AssocTuesday = AssocTuesday.Trim();

                if (AssocWednesday == "0" || AssocWednesday == " ")
                    AssocWednesday = AssocWednesday.Trim();

                if (AssocThursday == "0" || AssocThursday == " ")
                    AssocThursday = AssocThursday.Trim();

                if (AssocFriday == "0" || AssocFriday == " ")
                    AssocFriday = AssocFriday.Trim();

                if (AssocSaturday == "0" || AssocSaturday == " ")
                    AssocSaturday = AssocSaturday.Trim();

                if (AssocSunday == "0" || AssocSunday == " ")
                    AssocSunday = AssocSunday.Trim();
            }

            Category = Category.Trim();
            DateIndicator = DateIndicator.Trim();
            Location = Location.Trim();
            BaseLocationSuffix = BaseLocationSuffix.Trim();
            AssocLocationSuffix = AssocLocationSuffix.Trim();
            AssocType = AssocType.Trim();
            StpIndicator = StpIndicator.Trim();
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Association;
        }
    }
}