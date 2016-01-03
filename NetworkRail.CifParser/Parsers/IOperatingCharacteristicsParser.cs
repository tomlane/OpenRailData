using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IOperatingCharacteristicsParser
    {
        OperatingCharacteristics ParseOperatingCharacteristics(string characteristics);
    }
}