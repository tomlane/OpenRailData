using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class ExtractUpdateTypeParser : IExtractUpdateTypeParser
    {
        public ExtractUpdateType ParseExtractUpdateType(string extractUpdateType)
        {
            if (string.IsNullOrWhiteSpace(extractUpdateType))
                throw new ArgumentNullException(nameof(extractUpdateType));

            switch (extractUpdateType)
            {
                case "F":
                    return ExtractUpdateType.FullExtract;
                case "U":
                    return ExtractUpdateType.UpdateExtract;
                default:
                    throw new ArgumentException("Extract Type is not valid");
            }
        }
    }
}