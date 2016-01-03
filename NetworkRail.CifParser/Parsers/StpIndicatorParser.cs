using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class StpIndicatorParser : IStpIndicatorParser
    {
        public StpIndicator ParseStpIndicator(string stpIndicator)
        {
            switch (stpIndicator)
            {
                case "C":
                    return StpIndicator.Cancellation;
                case "N":
                    return StpIndicator.New;
                case "O":
                    return StpIndicator.Overlay;
                case "P":
                    return StpIndicator.Permanent;
                default:
                    throw new ArgumentException($"Unknown STP Indicator {stpIndicator}");
            }
        }
    }
}