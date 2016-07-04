using System;
using System.IO;
using Microsoft.Extensions.Options;

namespace OpenRailData.Darwin.ScheduleFetching
{
    public class LocalFileDarwinScheduleFetcher : IDarwinScheduleFetcher
    {
        private readonly IOptions<DarwinLocalFileFetcherOptions> _options;

        public LocalFileDarwinScheduleFetcher(IOptions<DarwinLocalFileFetcherOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _options = options;
        }

        public byte[] FetchSchedule()
        {
            if (string.IsNullOrWhiteSpace(_options.Value.DarwinScheduleFilePath))
                throw new ArgumentNullException("ScheduleFilePath");

            return File.ReadAllBytes(_options.Value.DarwinScheduleFilePath);
        }
    }
}