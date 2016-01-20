using System;
using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class HeaderRecordParserContainer : IHeaderRecordParserContainer
    {
        public IDateTimeParser DateTimeParser { get; }
        public IExtractUpdateTypeParser UpdateTypeParser { get; }
        public ITimeParser TimeParser { get; }

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