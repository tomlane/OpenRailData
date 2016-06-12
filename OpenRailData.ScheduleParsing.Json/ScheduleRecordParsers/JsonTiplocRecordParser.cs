using System;
using Newtonsoft.Json;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleParsing.Json.RawRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonTiplocRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "TiplocV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(recordString));

            var deserialziedTiploc = JsonConvert.DeserializeObject<DeserializedTiploc>(recordString);

            return new TiplocRecord
            {
                TiplocCode = deserialziedTiploc.TiplocCode,
                Stanox = deserialziedTiploc.Stanox,
                CrsCode = deserialziedTiploc.CrsCode,
                Nalco = deserialziedTiploc.Nalco,
                TpsDescription = deserialziedTiploc.TpsDescription,
                CapriDescription = deserialziedTiploc.Description
            };
        }
    }
}