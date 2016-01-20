using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class StpIndicatorParser : IStpIndicatorParser
    {
        public StpIndicator ParseStpIndicator(string stpIndicator)
        {
            if (string.IsNullOrWhiteSpace(stpIndicator))
                throw new ArgumentNullException(nameof(stpIndicator));

            switch (stpIndicator)
            {
                case "C":
                    return StpIndicator.C;
                case "N":
                    return StpIndicator.N;
                case "O":
                    return StpIndicator.O;
                case "P":
                    return StpIndicator.P;
                default:
                    throw new ArgumentException($"Unknown STP Indicator {stpIndicator}");
            }
        }
    }
}