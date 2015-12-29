using System;

namespace NetworkRail.CifParser.Entities
{
    public class AssociationRecord : ICifRecord
    {
        public string TransactionType { get; }
        public string MainTrainUid { get; }
        public string AssocTrainUid { get; }
        public string DateFrom { get; }
        public string DateTo { get; }
        public string AssocMonday { get; }
        public string AssocTuesday { get; }
        public string AssocWednesday { get; }
        public string AssocThursday { get; }
        public string AssocFriday { get; }
        public string AssocSaturday { get; }
        public string AssocSunday { get; }
        public string Category { get; }
        public string DateIndicator { get; }
        public string Location { get; }
        public string BaseLocationSuffix { get; }
        public string AssocLocationSuffix { get; }
        public string AssocType { get; }
        public string StpIndicator { get; }

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

        public override string ToString()
        {
            return $"Transaction Type: {TransactionType}" +
                   $" Main Train Uid: {MainTrainUid} " +
                   $"Assoc Train Uid: {AssocTrainUid} " +
                   $"Date From: {DateFrom} " +
                   $"Date To: {DateTo} " +
                   $"Monday: {AssocMonday} " +
                   $"Tuesday: {AssocTuesday} " +
                   $"Wednesday: {AssocWednesday} " +
                   $"Thursday: {AssocThursday} " +
                   $"Friday: {AssocFriday} " +
                   $"Saturday: {AssocSaturday} " +
                   $"Sunday: {AssocSunday} " +
                   $"Category: {Category} " +
                   $"Date Indicator: {DateIndicator} " +
                   $"Location: {Location} " +
                   $"Base Location Suffix: {BaseLocationSuffix} " +
                   $"Assoc Location Suffix: {AssocLocationSuffix} " +
                   $"Assoc Type: {AssocType} " +
                   $"Stp Indicator: {StpIndicator}";
        }
    }
}