namespace OpenRailData.Darwin.DataDecompression
{
    public interface IDataDecompressor
    {
        byte[] Decompress(byte[] data);
    }
}