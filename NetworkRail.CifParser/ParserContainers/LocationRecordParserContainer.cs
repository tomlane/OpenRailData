using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class LocationRecordParserContainer : ILocationRecordParserContainer
    {
        public ILocationTypeParser LocationTypeParser { get; set; }
        public ITimeParser TimeParser { get; set; }
        public ILocationActivityParser LocationActivityParser { get; set; }

        public LocationRecordParserContainer(ILocationTypeParser locationTypeParser, ITimeParser timeParser, ILocationActivityParser locationActivityParser)
        {
            if (locationTypeParser == null)
                throw new ArgumentNullException(nameof(locationTypeParser));
            if (timeParser == null)
                throw new ArgumentNullException(nameof(timeParser));
            if (locationActivityParser == null)
                throw new ArgumentNullException(nameof(locationActivityParser));

            LocationTypeParser = locationTypeParser;
            TimeParser = timeParser;
            LocationActivityParser = locationActivityParser;
        }
    }
}