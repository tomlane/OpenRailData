using System;
using System.Text.RegularExpressions;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class HeaderRecordBuilder : ICifRecordBuilder<HeaderRecord>
    {
        public HeaderRecord BuildRecord(string recordString)
        {
            HeaderRecord record = new HeaderRecord
            {
                MainFrameId = recordString.Substring(2, 20),
                DateExtract = recordString.Substring(22, 6),
                TimeExtract = recordString.Substring(28, 4),
                CurrentFileRef = recordString.Substring(32, 7),
                LastFileRef = recordString.Substring(39, 7),
                UpdateType = recordString.Substring(46, 1),
                ExtractStart = recordString.Substring(48, 6),
                ExtractEnd = recordString.Substring(54, 6)
            };

            Regex mainFrameUserRegex = new Regex("TPS.U(.{6}).PD(.{6})");

            if (mainFrameUserRegex.IsMatch(record.MainFrameId))
            {
                record.MainFrameUser = record.MainFrameId.Substring(5, 6);
                record.ExtractDate = record.MainFrameId.Substring(14, 6);
            }
            else
            {
                throw new ArgumentException("The main frame id is not valid in the header record.");
            }

            return record;
        }
    }
}