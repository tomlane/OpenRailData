using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class TiplocDeleteRecordBuilder : ICifRecordBuilder<TiplocDeleteRecord>
    {
        public TiplocDeleteRecord BuildRecord(string recordString)
        {
            TiplocDeleteRecord record = new TiplocDeleteRecord
            {
                TiplocCode = recordString.Substring(2, 7)
            };

            record.TiplocCode = record.TiplocCode.Trim();

            return record;
        }
    }
}