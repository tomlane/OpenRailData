using System;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class TimingAllowanceParser : ITimingAllowanceParser
    {
        public TimeSpan ParseTime(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString) || timeString == "0000")
                return new TimeSpan(0);
            
            timeString = timeString.Trim();

            var result = new TimeSpan();
            int minutes;

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
                    // TODO: Really, Tom? Really? Log these.
                    return new TimeSpan(0);
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
                    return new TimeSpan(0);
                }
            }
            
            return result;
        }
    }
}