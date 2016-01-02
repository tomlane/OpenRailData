using System;
using System.Text.RegularExpressions;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class HeaderRecordBuilder : ICifRecordBuilder<HeaderRecord>
    {
        public HeaderRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            HeaderRecord record = new HeaderRecord
            {
                MainFrameId = recordString.Substring(2, 20)
            };

            Regex mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (!mainFrameUserRegex.IsMatch(record.MainFrameId))
                throw new InvalidOperationException("The main frame id is not valid in the header record.");
            
            record.DateOfExtract = recordString.Substring(22, 6);
            record.TimeOfExtract = recordString.Substring(28, 4);
            record.CurrentFileRef = recordString.Substring(32, 7);
            record.LastFileRef = recordString.Substring(39, 7);
            record.UpdateType = recordString.Substring(46, 1);
            record.CifSoftwareVersion = recordString.Substring(47, 1);
            record.UserExtractStartDate = recordString.Substring(48, 6);
            record.UserExtractEndDate = recordString.Substring(54, 6);
            record.MainFrameUser = record.MainFrameId.Substring(5, 6);
            record.MainFrameExtractDate = record.MainFrameId.Substring(14, 6);

            return record;
        }
    }
}