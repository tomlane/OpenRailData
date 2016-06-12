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
                AssocTrainUid = deserializedAssociataion.Association.AssocTrainUid,
                AssocType = AssociationType.None,
                Location = deserializedAssociataion.Association.Location,
                StpIndicator = (StpIndicator)_propertyParsers["StpIndicator"].ParseProperty(deserializedAssociataion.Association.StpIndicator),
                DiagramType = "T",
                DateFrom = DateTime.Parse(deserializedAssociataion.Association.AssocStartDate).ToUniversalTime(),
                MainTrainUid = deserializedAssociataion.Association.MainTrainUid
            };

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.BaseLocationSuffix))
                association.BaseLocationSuffix = deserializedAssociataion.Association.BaseLocationSuffix;

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.AssocLocationSuffix))
                association.AssocLocationSuffix = deserializedAssociataion.Association.AssocLocationSuffix;

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.AssocDays))
                association.AssocDays = (Days)_propertyParsers["RunningDays"].ParseProperty(deserializedAssociataion.Association.AssocDays);

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.DateIndicator))
                association.DateIndicator = (DateIndicator)_propertyParsers["DateIndicator"].ParseProperty(deserializedAssociataion.Association.DateIndicator);

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.Category))
                association.Category = (AssociationCategory)_propertyParsers["AssociationCategory"].ParseProperty(deserializedAssociataion.Association.Category);

            if (!string.IsNullOrWhiteSpace(deserializedAssociataion.Association.AssocEndDate))
                association.DateTo = DateTime.Parse(deserializedAssociataion.Association.AssocEndDate).ToUniversalTime();

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