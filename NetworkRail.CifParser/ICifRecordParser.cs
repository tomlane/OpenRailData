using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface ICifRecordParser
    {
        ICifRecord ParseRecord(string record);
    }
}