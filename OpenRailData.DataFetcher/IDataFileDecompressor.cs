namespace OpenRailData.DataFetcher
{
    public interface IDataFileDecompressor
    {
        byte[] DecompressDataFile(byte[] file);
    }
}