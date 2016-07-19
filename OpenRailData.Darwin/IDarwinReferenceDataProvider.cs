using OpenRailData.Darwin.Entites.ReferenceData;

namespace OpenRailData.Darwin
{
    public interface IDarwinReferenceDataProvider
    {
        DarwinReferenceDataSet GetDataSet();
    }
}