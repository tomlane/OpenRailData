using OpenRailData.Domain.DarwinReferenceData;

namespace OpenRailData.Darwin
{
    public interface IDarwinReferenceDataProvider
    {
        DarwinReferenceDataSet GetDataSet();
    }
}