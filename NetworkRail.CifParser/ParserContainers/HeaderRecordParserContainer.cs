using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class HeaderRecordParserContainer : IHeaderRecordParserContainer
    {
        public IDateTimeParser DateTimeParser { get; set; }
        public IExtractUpdateTypeParser UpdateTypeParser { get; set; }
        public ITimeParser TimeParser { get; set; }

        public HeaderRecordParserContainer(IDateTimeParser dateTimeParser, IExtractUpdateTypeParser updateTypeParser, ITimeParser timeParser)
        {
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));
            if (updateTypeParser == null)
                throw new ArgumentNullException(nameof(updateTypeParser));
            if (timeParser == null)
                throw new ArgumentNullException(nameof(timeParser));

            DateTimeParser = dateTimeParser;
            UpdateTypeParser = updateTypeParser;
            TimeParser = timeParser;
        }
    }
}