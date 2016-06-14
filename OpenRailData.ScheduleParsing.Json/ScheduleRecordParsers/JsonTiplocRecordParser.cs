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

            var tiploc = new TiplocRecord
            {
                TiplocCode = deserialziedTiploc.Tiploc.TiplocCode ?? string.Empty,
                Stanox = deserialziedTiploc.Tiploc.Stanox ?? string.Empty,
                CrsCode = deserialziedTiploc.Tiploc.CrsCode ?? string.Empty,
                Nalco = deserialziedTiploc.Tiploc.Nalco ?? string.Empty,
                TpsDescription = deserialziedTiploc.Tiploc.TpsDescription ?? string.Empty,
                CapriDescription = deserialziedTiploc.Tiploc.Description ?? string.Empty
            };

            switch (deserialziedTiploc.Tiploc.TransactionType)
            {
                case "Create":
                    tiploc.RecordIdentity = ScheduleRecordType.TI;
                    break;
                case "Update":
                    tiploc.RecordIdentity = ScheduleRecordType.TA;
                    break;
                case "Delete":
                    tiploc.RecordIdentity = ScheduleRecordType.TD;
                    break;
            }

            return tiploc;
        }
    }
}