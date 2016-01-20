using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class HeaderRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public string MainFrameIdentity { get; set; } = string.Empty;
        public DateTime DateOfExtract { get; set; }
        public TimeSpan TimeOfExtract { get; set; }
        public string CurrentFileRef { get; set; } = string.Empty;
        public string LastFileRef { get; set; } = string.Empty;
        public ExtractUpdateType ExtractUpdateType { get; set; }
        public string CifSoftwareVersion { get; set; } = string.Empty;
        public DateTime UserExtractStartDate { get; set; }
        public DateTime UserExtractEndDate { get; set; }
        public string MainFrameUser { get; set; } = string.Empty;
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
    }
}