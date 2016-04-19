namespace OpenRailData.DataFetcher
{
    public interface IDataFileFetcher
    {
        byte[] FetchDataFile(string url);
    }
}