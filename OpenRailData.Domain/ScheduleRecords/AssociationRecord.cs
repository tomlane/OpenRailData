using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Domain.ScheduleRecords
{
    public class AssociationRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; set; }
        public string MainTrainUid { get; set; } = string.Empty;
        public string AssocTrainUid { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Days AssocDays { get; set; }
        public AssociationCategory Category { get; set; }
        public DateIndicator DateIndicator { get; set; }
        public string Location { get; set; } = string.Empty;
        public string BaseLocationSuffix { get; set; } = string.Empty;
        public string AssocLocationSuffix { get; set; } = string.Empty;
        public string DiagramType { get; set; } = string.Empty;
        public AssociationType AssocType { get; set; }
        public StpIndicator StpIndicator { get; set; }
        public string UniqueId { get; set; } = string.Empty;

        protected bool Equals(AssociationRecord other)
        {
            return AssocDays == other.AssocDays &&
                   string.Equals(AssocLocationSuffix, other.AssocLocationSuffix) &&
                   string.Equals(AssocTrainUid, other.AssocTrainUid) &&
                   AssocType == other.AssocType &&
                   string.Equals(BaseLocationSuffix, other.BaseLocationSuffix) &&
                   Category == other.Category &&
                   StartDate.Equals(other.StartDate) &&
                   DateIndicator == other.DateIndicator &&
                   EndDate.Equals(other.EndDate) &&
                   string.Equals(DiagramType, other.DiagramType) &&
                   string.Equals(Location, other.Location) &&
                   string.Equals(MainTrainUid, other.MainTrainUid) &&
                   RecordIdentity == other.RecordIdentity &&
                   StpIndicator == other.StpIndicator &&
                   string.Equals(UniqueId, other.UniqueId);
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
                hashCode = (hashCode * 397) ^ StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DateIndicator;
                hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
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
            return $"RecordIdentity: {RecordIdentity}, MainTrainUid: {MainTrainUid}, AssocTrainUid: {AssocTrainUid}, DateFrom: {StartDate}, DateTo: {EndDate}, AssocDays: {AssocDays}, Category: {Category}, DateIndicator: {DateIndicator}, Location: {Location}, BaseLocationSuffix: {BaseLocationSuffix}, AssocLocationSuffix: {AssocLocationSuffix}, DiagramType: {DiagramType}, AssocType: {AssocType}, StpIndicator: {StpIndicator}, UniqueId: {UniqueId}";
        }
    }
}