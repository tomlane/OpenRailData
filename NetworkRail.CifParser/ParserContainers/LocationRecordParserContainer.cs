using System;
using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class LocationRecordParserContainer : ILocationRecordParserContainer
    {
        public ITimeParser TimeParser { get; }
        public ILocationActivityParser LocationActivityParser { get; }

        public LocationRecordParserContainer(ITimeParser timeParser, ILocationActivityParser locationActivityParser)
        {
            if (timeParser == null)
                throw new ArgumentNullException(nameof(timeParser));
            if (locationActivityParser == null)
                throw new ArgumentNullException(nameof(locationActivityParser));

            TimeParser = timeParser;
            LocationActivityParser = locationActivityParser;
        }
    }
}