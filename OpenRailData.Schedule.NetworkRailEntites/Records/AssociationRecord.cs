using System;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailEntites.Records
{
    public class AssociationRecord : IScheduleRecord
    {
        public int Id { get; set; }
        public ScheduleRecordType RecordIdentity { get; set; }
        public string MainTrainUid { get; set; } = string.Empty;
        public string AssocTrainUid { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Days AssocDays { get; set; }
        public AssociationCategory Category { get; set; }
        public DateIndicator DateIndicator { get; set; }
        public string Location { get; set; } = string.Empty;
        public string BaseLocationSuffix { get; set; } = string.Empty;
        public string AssocLocationSuffix { get; set; } = string.Empty;
        public string DiagramType { get; set; } = string.Empty;
        public AssociationType AssocType { get; set; }
        public StpIndicator StpIndicator { get; set; }

        protected bool Equals(AssociationRecord other)
        {
            return Id == other.Id &&
                   AssocDays == other.AssocDays &&
                   string.Equals(AssocLocationSuffix, other.AssocLocationSuffix) &&
                   string.Equals(AssocTrainUid, other.AssocTrainUid) &&
                   AssocType == other.AssocType &&
                   string.Equals(BaseLocationSuffix, other.BaseLocationSuffix) &&
                   Category == other.Category &&
                   DateFrom.Equals(other.DateFrom) &&
                   DateIndicator == other.DateIndicator &&
                   DateTo.Equals(other.DateTo) &&
                   string.Equals(DiagramType, other.DiagramType) &&
                   string.Equals(Location, other.Location) &&
                   string.Equals(MainTrainUid, other.MainTrainUid) &&
                   RecordIdentity == other.RecordIdentity &&
                   StpIndicator == other.StpIndicator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((AssociationRecord)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)AssocDays;
                hashCode = (hashCode * 397) ^ (AssocLocationSuffix != null ? AssocLocationSuffix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AssocTrainUid != null ? AssocTrainUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)AssocType;
                hashCode = (hashCode * 397) ^ (BaseLocationSuffix != null ? BaseLocationSuffix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Category;
                hashCode = (hashCode * 397) ^ DateFrom.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DateIndicator;
                hashCode = (hashCode * 397) ^ DateTo.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiagramType != null ? DiagramType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MainTrainUid != null ? MainTrainUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)RecordIdentity;
                hashCode = (hashCode * 397) ^ (int)StpIndicator;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"AssocDays: {AssocDays}, AssocLocationSuffix: {AssocLocationSuffix}, AssocTrainUid: {AssocTrainUid}, AssocType: {AssocType}, BaseLocationSuffix: {BaseLocationSuffix}, Category: {Category}, DateFrom: {DateFrom}, DateIndicator: {DateIndicator}, DateTo: {DateTo}, DiagramType: {DiagramType}, Id: {Id}, Location: {Location}, MainTrainUid: {MainTrainUid}, RecordIdentity: {RecordIdentity}, StpIndicator: {StpIndicator}";
        }
    }
}