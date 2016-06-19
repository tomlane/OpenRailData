using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Domain.ScheduleRecords
{
    public class AssociationRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
        /// <summary>
        /// Main train uid.
        /// </summary>
        public string MainTrainUid { get; set; } = string.Empty;
        /// <summary>
        /// Assoc train uid.
        /// </summary>
        public string AssocTrainUid { get; set; } = string.Empty;
        /// <summary>
        /// Association start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Association end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Association days.
        /// </summary>
        public Days AssocDays { get; set; }
        /// <summary>
        /// Association category.
        /// </summary>
        public AssociationCategory Category { get; set; }
        /// <summary>
        /// Date indicator.
        /// </summary>
        public DateIndicator DateIndicator { get; set; }
        /// <summary>
        /// Location.
        /// </summary>
        public string Location { get; set; } = string.Empty;
        /// <summary>
        /// Base location suffix.
        /// </summary>
        public string BaseLocationSuffix { get; set; } = string.Empty;
        /// <summary>
        /// Association location suffix.
        /// </summary>
        public string AssocLocationSuffix { get; set; } = string.Empty;
        /// <summary>
        /// Diagram type.
        /// </summary>
        public string DiagramType { get; set; } = string.Empty;
        /// <summary>
        /// Association type.
        /// </summary>
        public AssociationType AssocType { get; set; }
        /// <summary>
        /// Association STP indicator.
        /// </summary>
        public StpIndicator StpIndicator { get; set; }
        /// <summary>
        /// Unique identifier for the record. Can be used as a primary key on searches.
        /// </summary>
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