using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class SleeperDetailsParser : ISleeperDetailsParser
    {
        public SleeperDetails ParseTrainSleeperDetails(string sleeperDetails)
        {
            if (sleeperDetails == null)
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
                    return SleeperDetails.NotAvailable;
            }
        }
    }
}