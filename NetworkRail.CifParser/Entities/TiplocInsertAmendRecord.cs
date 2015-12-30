using NetworkRail.CifParser.Utils;

namespace NetworkRail.CifParser.Entities
{
    public class TiplocInsertAmendRecord : ICifRecord
    {
        public string RecordType { get; } = string.Empty;
        public string TiplocCode { get; }
        public string Nlc { get; }
        public string TpsDescription { get; }
        public string Stanox { get; }
        public string Crs { get; }
        public string CapriDescription { get; }
        public string OldTiploc { get; }

        public bool IsAmend => !string.IsNullOrEmpty(OldTiploc);

        public TiplocInsertAmendRecord(string record)
        {
            Nlc = record.Substring(11, 6);
            TpsDescription = record.Substring(18, 26);
            Stanox = record.Substring(44, 5);
            Crs = record.Substring(53, 3);
            CapriDescription = record.Substring(56, 16);

            if (record.Substring(0, 2) == "TI")
            {
                RecordType = "I";
                OldTiploc = string.Empty;
                TiplocCode = record.Substring(2, 7);
            }
            else if (record.Substring(0, 2) == "TA")
            {
                RecordType = "A";
                string newTiploc = record.Substring(72, 7).Trim();

                if (newTiploc == string.Empty)
                {
                    TiplocCode = record.Substring(2, 7);
                    OldTiploc = string.Empty;
                }
                else
                {
                    OldTiploc = record.Substring(2, 7);
                    TiplocCode = newTiploc;
                }
            }
            else
            {
                OldTiploc = string.Empty;
                TiplocCode = record.Substring(2, 7);
            }

            Nlc = Nlc.Trim();
            Crs = Crs.Trim();
            TpsDescription = TpsDescription.Trim();
            CapriDescription = CapriDescription.Trim();
            TiplocCode = TiplocCode.Trim();
            OldTiploc = OldTiploc.Trim();

            TpsDescription = TpsDescription.LocationCasing();
            CapriDescription = CapriDescription.LocationCasing();
        }

        public CifRecordType GetRecordType()
        {
            if (RecordType == "I")
                return CifRecordType.TiplocInsert;

            if (RecordType == "A" && OldTiploc == string.Empty)
                    return CifRecordType.TiplocAmend;

            return CifRecordType.TiplocAmendOther;

        }
    }
}