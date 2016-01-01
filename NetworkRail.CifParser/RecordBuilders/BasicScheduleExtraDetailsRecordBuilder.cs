using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class BasicScheduleExtraDetailsRecordBuilder : ICifRecordBuilder<BasicScheduleExtraDetailsRecord>
    {
        public BasicScheduleExtraDetailsRecord BuildRecord(string recordString)
        {
            BasicScheduleExtraDetailsRecord record = new BasicScheduleExtraDetailsRecord
            {
                UicCode = recordString.Substring(6, 5),
                AtocCode = recordString.Substring(11, 2),
                AtsCode = recordString.Substring(13, 1),
                Rsid = recordString.Substring(14, 8),
                DataSource = recordString.Substring(22, 1)
            };

            record.UicCode = record.UicCode.Trim();
            record.AtocCode = record.AtocCode.Trim();
            record.AtsCode = record.AtsCode.Trim();
            record.Rsid = record.Rsid.Trim();
            record.DataSource = record.DataSource.Trim();

            return record;
        }
    }
}