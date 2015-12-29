using System.Globalization;

namespace NetworkRail.CifParser.Utils
{
    public static class StringCasing
    {
        public static string LocationCasing(string line)
        {
            var textInfo = new CultureInfo("en-GB", false).TextInfo;

            return textInfo.ToTitleCase(line);
        }
    }
}