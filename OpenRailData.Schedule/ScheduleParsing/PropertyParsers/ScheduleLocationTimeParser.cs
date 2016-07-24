using System.Globalization;
using NodaTime;
using NodaTime.Text;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public static class ScheduleLocationTimeParser
    {
        public static LocalTime? ParseLocationTimeString(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return null;

            // e.g. 1430
            if (timeString.Length == 4)
            {
                return LocalTimePattern.Create("HHmm", CultureInfo.InvariantCulture).Parse(timeString).Value;
            }

            // e.g. 1430H => 143030
            if (timeString.Contains("H"))
            {
                timeString = timeString.Replace("H", "30");

                return LocalTimePattern.Create("HHmmss", CultureInfo.InvariantCulture).Parse(timeString).Value;
            }

            // e.g. 14:30:30
            return LocalTimePattern.CreateWithInvariantCulture("HH:mm:ss").Parse(timeString).Value;
        }

        public static string ParseLocalTimeInstance(LocalTime? localTime)
        {
            if (localTime == null)
                return string.Empty;

            return localTime.ToString();
        }
    }
}