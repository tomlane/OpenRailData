﻿using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class WebScheduleFileFetcher : IScheduleFileFetcher
    {
        private readonly IConfigManager _configManager;
        private readonly IFetchScheduleUrlProvider _scheduleUrlProvider;

        public WebScheduleFileFetcher(IConfigManager configManager, IFetchScheduleUrlProvider scheduleUrlProvider)
        {
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));
            if (scheduleUrlProvider == null)
                throw new ArgumentNullException(nameof(scheduleUrlProvider));

            _configManager = configManager;
            _scheduleUrlProvider = scheduleUrlProvider;
        }

        public byte[] FetchDailyScheduleUpdateFile()
        {
            return GetScheduleFile(_scheduleUrlProvider.GetDailyUpdateScheduleUrl());
        }

        public byte[] FetchWeeklyScheduleFile()
        {
            return GetScheduleFile(_scheduleUrlProvider.GetWeeklyScheduleUrl());
        }

        private byte[] GetScheduleFile(string url)
        {
            Trace.TraceInformation("Preparing web request for the following url: {0}", url);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(_configManager.GetConfigSetting("username") + ":" + _configManager.GetConfigSetting("password")));
            request.Headers.Add("Authorization", "Basic " + encoded);

            var response = (HttpWebResponse)request.GetResponse();

            Trace.TraceInformation("Response received for web request.");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException("Failed to fetch daily schedule update");

            using (var responseStream = response.GetResponseStream())
            using (var memoryStream = new MemoryStream())
            {
                responseStream?.CopyTo(memoryStream);
                return DecompressBytes(memoryStream.ToArray());
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

    public interface IScheduleFileFetcher
    {
        byte[] FetchDailyScheduleUpdateFile();
        byte[] FetchWeeklyScheduleFile();
    }
}