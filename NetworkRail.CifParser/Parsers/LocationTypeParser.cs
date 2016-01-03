using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class LocationTypeParser : ILocationTypeParser
    {
        public LocationType ParseLocationType(string locationType)
        {
            switch (locationType)
            {
                case "LO":
                    return LocationType.Originating;
                case "LI":
                    return LocationType.Intermediate;
                case "LT":
                    return LocationType.Terminating;
                default:
                    throw new ArgumentException($"Unknown Location Type {locationType}");
            }
        }
    }
}