namespace NetworkRail.CifParser.Records
{
    public class HeaderRecord : ICifRecord
    {
        public string MainFrameId { get; set; } = string.Empty;
        public string DateOfExtract { get; set; } = string.Empty;
        public string TimeOfExtract { get; set; } = string.Empty;
        public string CurrentFileRef { get; set; } = string.Empty;
        public string LastFileRef { get; set; } = string.Empty;
        public string UpdateType { get; set; } = string.Empty;
        public string CifSoftwareVersion { get; set; } = string.Empty;
        public string UserExtractStartDate { get; set; } = string.Empty;
        public string UserExtractEndDate { get; set; } = string.Empty;
        public string MainFrameUser { get; set; } = string.Empty;
        public string MainFrameExtractDate { get; set; } = string.Empty;

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Header;
        }
    }
}