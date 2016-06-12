using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.Json.RawRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonAssociationRecordParser : IScheduleRecordParser
    {
        private Dictionary<string, IRecordEnumPropertyParser> _propertyParsers;

        public string RecordKey { get; } = "JsonAssociationV1";

        public JsonAssociationRecordParser(IRecordEnumPropertyParser[] propertyParsers)
        {
            if (propertyParsers == null)
                throw new ArgumentNullException(nameof(propertyParsers));

            _propertyParsers = propertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(recordString));

            var deserializedAssociataion = JsonConvert.DeserializeObject<DeserializedAssociation>(recordString);

            throw new NotImplementedException();

            return new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAN,
                AssocDays = (Days)_propertyParsers["RunningDays"].ParseProperty(deserializedAssociataion.Association.AssocDays),
                AssocLocationSuffix = deserializedAssociataion.Association.AssocLocationSuffix,
                AssocTrainUid = deserializedAssociataion.Association.AssocTrainUid,
                
                
            };
        }
    }
}