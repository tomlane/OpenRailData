using System.Globalization;

namespace OpenRailData.Modules.ScheduleParsing.Cif.Utils
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