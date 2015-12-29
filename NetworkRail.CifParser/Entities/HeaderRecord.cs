using System;
using System.Text.RegularExpressions;

namespace NetworkRail.CifParser.Entities
{
    public class HeaderRecord : ICifRecord
    {
        public string MainFrameId { get; }
        public string DateExtract { get; }
        public string TimeExtract { get; }
        public string CurrentFileRef { get; }
        public string LastFileRef { get; }
        public string UpdateType { get; }
        public string ExtractStart { get; }
        public string ExtractEnd { get; }
        public string MainFrameUser { get; }
        public string ExtractDate { get; }

        public HeaderRecord(string record)
        {
            MainFrameId = record.Substring(2, 20);
            DateExtract = record.Substring(22, 6);
            TimeExtract = record.Substring(28, 4);
            CurrentFileRef = record.Substring(32, 7);
            LastFileRef = record.Substring(39, 7);
            UpdateType = record.Substring(46, 1);
            ExtractStart = record.Substring(48, 6);
            ExtractEnd = record.Substring(54, 6);

            Regex mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (mainFrameUserRegex.IsMatch(MainFrameId))
            {
                MainFrameUser = MainFrameId.Substring(5, 6);
                ExtractDate = MainFrameId.Substring(14, 6);
            }
            else
            {
                throw new ArgumentException("The main frame id is not valid in the header record.");
            }
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Header;
        }

        public override string ToString()
        {
            return $"Main Frame ID: {MainFrameId}" +
                   $" Date Extract: {DateExtract} " +
                   $"Time Extract: {TimeExtract} " +
                   $"Current File Ref: {CurrentFileRef} " +
                   $"Last File Ref: {LastFileRef} " +
                   $"Update Type: {UpdateType} " +
                   $"Extract Start: {ExtractStart} " +
                   $"Extract End {ExtractEnd} " +
                   $"Main Frame User: {MainFrameUser} " +
                   $"Extract Date: {ExtractDate}";
        }
    }
}