using System;
using System.Collections.Generic;
using System.IO;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class ScheduleFileRecordExtractor : IScheduleFileRecordExtractor
    {
        public IEnumerable<string> ExtractScheduleFileRecords(byte[] scheduleFile)
        {
            if (scheduleFile == null) 
                throw new ArgumentNullException(nameof(scheduleFile));

            var recordsToParse = new List<string>();

            using (var streamReader = new StreamReader(new MemoryStream(scheduleFile)))
            {
                string record;
                while ((record = streamReader.ReadLine()) != null)
                {
                    recordsToParse.Add(record);
                }
            }

            return recordsToParse;
        }
    }
}