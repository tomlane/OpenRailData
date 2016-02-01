using System.Globalization;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Utils
{
    public static class StringExtensions
    {
        public static string LocationCasing(this string value)
        {
            var textInfo = new CultureInfo("en-GB", false).TextInfo;

            return textInfo.ToTitleCase(value);
        }
    }
}