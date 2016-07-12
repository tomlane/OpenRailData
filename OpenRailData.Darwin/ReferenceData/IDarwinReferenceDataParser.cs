using OpenRailData.Domain.DarwinReferenceData;

namespace OpenRailData.Darwin.ReferenceData
{
    public interface IDarwinReferenceDataParser
    {
        DarwinReferenceDataSet ParDarwinReferenceDataSet(string rawData);
    }
}