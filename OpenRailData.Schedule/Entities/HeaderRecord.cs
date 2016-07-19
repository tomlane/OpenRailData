using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.Entities
{
    public class HeaderRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
        /// <summary>
        /// Main frame identity.
        /// </summary>
        public string MainFrameIdentity { get; set; } = string.Empty;
        /// <summary>
        /// Date of extract.
        /// </summary>
        public DateTime DateOfExtract { get; set; }
        /// <summary>
        /// Time of extract.
        /// </summary>
        public string TimeOfExtract { get; set; } = string.Empty;
        /// <summary>
        /// Current file reference.
        /// </summary>
        public string CurrentFileRef { get; set; } = string.Empty;
        /// <summary>
        /// Last file reference.
        /// </summary>
        public string LastFileRef { get; set; } = string.Empty;
        /// <summary>
        /// Extract update type.
        /// </summary>
        public ExtractUpdateType ExtractUpdateType { get; set; }
        /// <summary>
        /// Cif Software Version.
        /// </summary>
        public string CifSoftwareVersion { get; set; } = string.Empty;
        /// <summary>
        /// User extract start date.
        /// </summary>
        public DateTime? UserExtractStartDate { get; set; }
        /// <summary>
        /// User extract end date.
        /// </summary>
        public DateTime? UserExtractEndDate { get; set; }
        /// <summary>
        /// Main frame user.
        /// </summary>
        public string MainFrameUser { get; set; } = string.Empty;
        /// <summary>
        /// Main frame extract date.
        /// </summary>
        public DateTime MainFrameExtractDate { get; set; }

        protected bool Equals(HeaderRecord other)
        {
            return RecordIdentity == other.RecordIdentity && 
                string.Equals(MainFrameIdentity, other.MainFrameIdentity) && 
                DateOfExtract.Equals(other.DateOfExtract) && 
                TimeOfExtract.Equals(other.TimeOfExtract) && 
                string.Equals(CurrentFileRef, other.CurrentFileRef) && 
                string.Equals(LastFileRef, other.LastFileRef) && 
                ExtractUpdateType == other.ExtractUpdateType && 
                string.Equals(CifSoftwareVersion, other.CifSoftwareVersion) && 
                UserExtractStartDate.Equals(other.UserExtractStartDate) && 
                UserExtractEndDate.Equals(other.UserExtractEndDate) && 
                string.Equals(MainFrameUser, other.MainFrameUser) && 
                MainFrameExtractDate.Equals(other.MainFrameExtractDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((HeaderRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (MainFrameIdentity != null ? MainFrameIdentity.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DateOfExtract.GetHashCode();
                hashCode = (hashCode*397) ^ TimeOfExtract.GetHashCode();
                hashCode = (hashCode*397) ^ (CurrentFileRef != null ? CurrentFileRef.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastFileRef != null ? LastFileRef.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) ExtractUpdateType;
                hashCode = (hashCode*397) ^ (CifSoftwareVersion != null ? CifSoftwareVersion.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UserExtractStartDate.GetHashCode();
                hashCode = (hashCode*397) ^ UserExtractEndDate.GetHashCode();
                hashCode = (hashCode*397) ^ (MainFrameUser != null ? MainFrameUser.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ MainFrameExtractDate.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"RecordIdentity: {RecordIdentity}, MainFrameIdentity: {MainFrameIdentity}, DateOfExtract: {DateOfExtract}, TimeOfExtract: {TimeOfExtract}, CurrentFileRef: {CurrentFileRef}, LastFileRef: {LastFileRef}, ExtractUpdateType: {ExtractUpdateType}, CifSoftwareVersion: {CifSoftwareVersion}, UserExtractStartDate: {UserExtractStartDate}, UserExtractEndDate: {UserExtractEndDate}, MainFrameUser: {MainFrameUser}, MainFrameExtractDate: {MainFrameExtractDate}";
        }
    }
}