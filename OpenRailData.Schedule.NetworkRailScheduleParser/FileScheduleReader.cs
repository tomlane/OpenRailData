using System;
using System.Collections.Generic;
using System.IO;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class FileScheduleReader : IScheduleReader
    {
        public IEnumerable<string> ReadSchedule(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            return File.ReadLines(filePath);
        }
    }
}