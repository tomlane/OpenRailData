namespace OpenRailData.Darwin.DataFetching
{
    public interface IDarwinDataFileFetcher
    {
        byte[] FetchFile(string filePath);
    }
}