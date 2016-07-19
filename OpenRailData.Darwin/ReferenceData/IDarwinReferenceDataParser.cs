using OpenRailData.Darwin.Entites.ReferenceData;

namespace OpenRailData.Darwin.ReferenceData
{
    public interface IDarwinReferenceDataParser
    {
        DarwinReferenceDataSet ParseDarwinReferenceDataSet(string rawData);
    }
}