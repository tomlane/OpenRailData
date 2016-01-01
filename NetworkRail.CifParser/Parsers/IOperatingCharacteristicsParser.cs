using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.Parsers
{
    public interface IOperatingCharacteristicsParser
    {
        OperatingCharacteristics ParseOperatingCharacteristics(string characteristics);
    }
}