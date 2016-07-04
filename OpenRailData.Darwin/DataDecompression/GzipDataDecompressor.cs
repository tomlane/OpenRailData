using System;
using System.IO;
using System.IO.Compression;

namespace OpenRailData.Darwin.DataDecompression
{
    public class GzipDataDecompressor : IDataDecompressor
    {
        public byte[] Decompress(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            // Shamefully borrowed from Dot Net Pearls.
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(data), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
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