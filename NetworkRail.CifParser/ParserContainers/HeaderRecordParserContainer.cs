using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class HeaderRecordParserContainer : IHeaderRecordParserContainer
    {
        public IDateTimeParser DateTimeParser { get; set; }
        public IExtractUpdateTypeParser UpdateTypeParser { get; set; }

        public HeaderRecordParserContainer(IDateTimeParser dateTimeParser, IExtractUpdateTypeParser updateTypeParser)
        {
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));
            if (updateTypeParser == null)
                throw new ArgumentNullException(nameof(updateTypeParser));

            DateTimeParser = dateTimeParser;
            UpdateTypeParser = updateTypeParser;
        }
    }
}