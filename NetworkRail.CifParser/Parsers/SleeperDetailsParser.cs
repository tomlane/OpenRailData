using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class SleeperDetailsParser : ISleeperDetailsParser
    {
        public SleeperDetails ParseTrainSleeperDetails(string sleeperDetails)
        {
            if (string.IsNullOrWhiteSpace(sleeperDetails))
                throw new ArgumentNullException(nameof(sleeperDetails));

            switch (sleeperDetails)
            {
                case "B":
                    return SleeperDetails.FirstAndStandard;
                case "F":
                    return SleeperDetails.FirstClassOnly;
                case "S":
                    return SleeperDetails.StandardClassOnly;
                default:
                    throw new ArgumentException($"Unknown Sleeper Details: {sleeperDetails}");
            }
        }
    }
}