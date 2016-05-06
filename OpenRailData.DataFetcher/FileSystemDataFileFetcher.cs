using System;
using System.IO;

namespace OpenRailData.DataFetcher
{
    public class FileSystemDataFileFetcher : IDataFileFetcher
    {
        public byte[] FetchDataFile(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            return File.ReadAllBytes(url);
        }
    }
}