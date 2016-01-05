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
    }
}