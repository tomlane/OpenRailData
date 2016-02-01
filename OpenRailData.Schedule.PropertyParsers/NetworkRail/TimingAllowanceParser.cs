using System;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public class TimingAllowanceParser : ITimingAllowanceParser
    {
        public TimeSpan? ParseTime(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString) || timeString == "0000")
                return null;
            
            timeString = timeString.Trim();

            TimeSpan result = new TimeSpan();
            int minutes = 0;

            if (timeString[timeString.Length - 1] == 'H')
            {
                result = TimeSpan.FromSeconds(30);
                timeString = timeString.Remove(timeString.Length - 1);
            }

            if (timeString == string.Empty)
                return result;

            if (timeString.Length <= 2)
            {
                try
                {
                    minutes = int.Parse(timeString);
                }
                catch (FormatException)
                {
                    return null;
                }

                return result.Add(TimeSpan.FromMinutes(minutes));
            }

            if (timeString.Length == 4)
            {
                try
                {
                    var hours = int.Parse(timeString.Substring(0, 2));
                    result = result.Add(TimeSpan.FromHours(hours));

                    minutes = int.Parse(timeString.Substring(2, 2));
                    result = result.Add(TimeSpan.FromMinutes(minutes));
                }
                catch (FormatException)
                {
                    return null;
                }
            }
            
            return result;
        }
    }
}