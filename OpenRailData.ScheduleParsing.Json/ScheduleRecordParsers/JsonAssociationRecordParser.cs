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
        private readonly Dictionary<string, IRecordEnumPropertyParser> _propertyParsers;

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
            
            var association = new AssociationRecord
            {
                AssocDays = (Days)_propertyParsers["RunningDays"].ParseProperty(deserializedAssociataion.Association.AssocDays),
                AssocLocationSuffix = String.Empty,
                AssocTrainUid = deserializedAssociataion.Association.AssocTrainUid,
                AssocType = AssociationType.None,
                DateTo = DateTime.Parse(deserializedAssociataion.Association.AssocEndDate).ToUniversalTime(),
                Location = deserializedAssociataion.Association.Location,
                BaseLocationSuffix = string.Empty,
                DateIndicator = (DateIndicator)_propertyParsers["DateIndicator"].ParseProperty(deserializedAssociataion.Association.DateIndicator),
                StpIndicator = (StpIndicator)_propertyParsers["StpIndicator"].ParseProperty(deserializedAssociataion.Association.StpIndicator),
                DiagramType = "T",
                DateFrom = DateTime.Parse(deserializedAssociataion.Association.AssocStartDate).ToUniversalTime(),
                Category = (AssociationCategory)_propertyParsers["AssociationCategory"].ParseProperty(deserializedAssociataion.Association.Category),
                MainTrainUid = deserializedAssociataion.Association.MainTrainUid
            };

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.BaseLocationSuffix))
                association.BaseLocationSuffix = deserializedAssociataion.Association.BaseLocationSuffix;

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.AssocLocationSuffix))
                association.AssocLocationSuffix = deserializedAssociataion.Association.AssocLocationSuffix;

            switch (deserializedAssociataion.Association.TransactionType)
            {
                case "Create":
                    association.RecordIdentity = ScheduleRecordType.AAN;
                    break;
                case "Update":
                    association.RecordIdentity = ScheduleRecordType.AAR;
                    break;
                case "Delete":
                    association.RecordIdentity = ScheduleRecordType.AAD;
                    break;
            }

            return association;
        }
    }
}