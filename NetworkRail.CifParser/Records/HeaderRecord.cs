namespace NetworkRail.CifParser.Records
{
    public class HeaderRecord : ICifRecord
    {
        public string MainFrameId { get; set; } = string.Empty;
        public string DateExtract { get; set; } = string.Empty;
        public string TimeExtract { get; set; } = string.Empty;
        public string CurrentFileRef { get; set; } = string.Empty;
        public string LastFileRef { get; set; } = string.Empty;
        public string UpdateType { get; set; } = string.Empty;
        public string ExtractStart { get; set; } = string.Empty;
        public string ExtractEnd { get; set; } = string.Empty;
        public string MainFrameUser { get; set; } = string.Empty;
        public string ExtractDate { get; set; } = string.Empty;

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Header;
        }
    }
}