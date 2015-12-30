using NetworkRail.CifParser.Entities;

namespace NetworkRail.CifParser
{
    public interface ICifRecordParser
    {
        ICifRecord ParseRecord(string record);
    }
}