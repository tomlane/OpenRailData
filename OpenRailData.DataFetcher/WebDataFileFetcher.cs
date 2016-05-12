using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using OpenRailData.Configuration;

namespace OpenRailData.DataFetcher
{
    public class WebDataFileFetcher : IDataFileFetcher
    {
        private readonly IConfigManager _configManager;

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

            var request = (HttpWebRequest)WebRequest.Create(url);

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(_configManager.GetConfigSetting("username") + ":" + _configManager.GetConfigSetting("password")));
            request.Headers.Add("Authorization", "Basic " + encoded);

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException($"Failed to fetch file from {url}");

            using (var responseStream = response.GetResponseStream())
            using (var memoryStream = new MemoryStream())
            {
                responseStream?.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}