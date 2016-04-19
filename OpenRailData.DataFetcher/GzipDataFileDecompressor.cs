using System;
using System.IO;
using System.IO.Compression;

namespace OpenRailData.DataFetcher
{
    public class GzipDataFileDecompressor : IDataFileDecompressor
    {
        public byte[] DecompressDataFile(byte[] file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (var stream = new GZipStream(new MemoryStream(file), CompressionMode.Decompress))
            {
                const int size = 4096;
                var buffer = new byte[size];
                using (var memory = new MemoryStream())
                {
                    int count;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }
}