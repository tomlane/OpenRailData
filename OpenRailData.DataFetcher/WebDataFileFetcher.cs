using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using Common.Logging;
using OpenRailData.Configuration;

namespace OpenRailData.DataFetcher
{
    public class WebDataFileFetcher : IDataFileFetcher
    {
        private readonly IConfigManager _configManager;
        private readonly ILog Logger = LogManager.GetLogger("Schedule.Util.CifScheduleFileFetcher");
        
        public WebDataFileFetcher(IConfigManager configManager)
        {
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));

            _configManager = configManager;
        }

        public byte[] FetchDataFile(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            if (Logger.IsInfoEnabled)
                Logger.Info($"Preparing web request for the following url: {url}");

            var request = (HttpWebRequest)WebRequest.Create(url);

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(_configManager.GetConfigSetting("username") + ":" + _configManager.GetConfigSetting("password")));
            request.Headers.Add("Authorization", "Basic " + encoded);

            var response = (HttpWebResponse)request.GetResponse();

            if (Logger.IsInfoEnabled)
                Logger.Info("Response received for web request.");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException($"Failed to fetch file from {url}");

            using (var responseStream = response.GetResponseStream())
            using (var memoryStream = new MemoryStream())
            {
                responseStream?.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private byte[] DecompressBytes(byte[] bytesToDecompress)
        {
            if (bytesToDecompress == null)
                throw new ArgumentNullException(nameof(bytesToDecompress));

            using (var stream = new GZipStream(new MemoryStream(bytesToDecompress), CompressionMode.Decompress))
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