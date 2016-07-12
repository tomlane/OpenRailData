using System.IO;

namespace OpenRailData.Darwin.DataFetching
{
    public class LocalDarwinDataFileFetcher : IDarwinDataFileFetcher
    {
        public byte[] FetchFile(string filePath)
        {
            
            return File.ReadAllBytes(filePath);
        }
    }
}