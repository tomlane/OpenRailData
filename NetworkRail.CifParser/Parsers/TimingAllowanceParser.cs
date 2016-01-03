using System;

namespace NetworkRail.CifParser.Parsers
{
    public class TimingAllowanceParser : ITimingAllowanceParser
    {
        public TimeSpan? ParseTimingAllowance(string timingAllowance)
        {
            if (string.IsNullOrWhiteSpace(timingAllowance))
            {
                return null;
            }

            int minutes;

            if (timingAllowance.Length == 1)
            {
                if (timingAllowance.Contains("H"))
                    return TimeSpan.FromSeconds(30);

                try
                {
                    minutes = int.Parse(timingAllowance);
                }
                catch (FormatException)
                {
                    return null;
                }

                return TimeSpan.FromMinutes(minutes);
            }

            TimeSpan result = new TimeSpan();

            if (timingAllowance.Contains("H"))
            {
                result = TimeSpan.FromSeconds(30);
                timingAllowance = timingAllowance.Replace('H', ' ');
            }

            try
            {
                minutes = int.Parse(timingAllowance);
            }
            catch (FormatException)
            {
                return null;
            }

            result = result.Add(TimeSpan.FromMinutes(minutes));

            return result;
        }
    }
}