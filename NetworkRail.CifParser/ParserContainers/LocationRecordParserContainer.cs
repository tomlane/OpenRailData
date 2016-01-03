using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class LocationRecordParserContainer : ILocationRecordParserContainer
    {
        public ILocationTypeParser LocationTypeParser { get; set; }
        public ILocationTimeParser LocationTimeParser { get; set; }
        public ITimingAllowanceParser TimingAllowanceParser { get; set; }
        public ILocationActivityParser LocationActivityParser { get; set; }

        public LocationRecordParserContainer(ILocationTypeParser locationTypeParser, ILocationTimeParser locationTimeParser, ITimingAllowanceParser timingAllowanceParser, ILocationActivityParser locationActivityParser)
        {
            if (locationTypeParser == null)
                throw new ArgumentNullException(nameof(locationTypeParser));
            if (locationTimeParser == null)
                throw new ArgumentNullException(nameof(locationTimeParser));
            if (timingAllowanceParser == null)
                throw new ArgumentNullException(nameof(timingAllowanceParser));
            if (locationActivityParser == null)
                throw new ArgumentNullException(nameof(locationActivityParser));

            LocationTypeParser = locationTypeParser;
            LocationTimeParser = locationTimeParser;
            TimingAllowanceParser = timingAllowanceParser;
            LocationActivityParser = locationActivityParser;
        }
    }
}