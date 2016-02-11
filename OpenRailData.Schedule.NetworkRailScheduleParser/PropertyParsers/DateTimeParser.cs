using System;
using System.Globalization;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class DateTimeParser : IDateTimeParser
    {
        public DateTime? ParseDateTime(DateTimeParserRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            if (string.IsNullOrWhiteSpace(request.DateTimeFormat))
                throw new ArgumentNullException("Format string can not be null.");

            if (string.IsNullOrWhiteSpace(request.DateTimeString))
                return null;


            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-UK");

            // year should be 19xx if > 60 and 20xx if < 60
            culture.Calendar.TwoDigitYearMax = 2059;
            
            DateTime result;

            bool successful = DateTime.TryParseExact(request.DateTimeString, request.DateTimeFormat, culture,
                DateTimeStyles.AdjustToUniversal, out result);

            if (successful)
                return result;

            return null;
        }
    }
}