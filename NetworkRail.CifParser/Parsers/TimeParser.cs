using System;

namespace NetworkRail.CifParser.Parsers
{
    public class TimeParser : ITimeParser
    {
        public TimeSpan? ParseNullableTime(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
            {
                return null;
            }

            int minutes;

            if (timeString.Length == 1)
            {
                if (timeString.Contains("H"))
                    return TimeSpan.FromSeconds(30);

                try
                {
                    minutes = int.Parse(timeString);
                }
                catch (FormatException)
                {
                    return null;
                }

                return TimeSpan.FromMinutes(minutes);
            }

            TimeSpan result = new TimeSpan();

            if (timeString.Contains("H"))
            {
                result = TimeSpan.FromSeconds(30);
                timeString = timeString.Replace('H', ' ');
            }

            try
            {
                minutes = int.Parse(timeString);
            }
            catch (FormatException)
            {
                return null;
            }

            result = result.Add(TimeSpan.FromMinutes(minutes));

            return result;
        }

        public TimeSpan ParseTime(string timeString)
        {
            throw new NotImplementedException();
        }
    }
}