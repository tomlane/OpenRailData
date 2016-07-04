using System;
using Microsoft.Extensions.Options;

namespace OpenRailData.Darwin.ScheduleFetching
{
    public class FtpDarwinScheduleFetcher : IDarwinScheduleFetcher
    {
        private readonly IOptions<DarwinFtpOptions> _options;

        public FtpDarwinScheduleFetcher(IOptions<DarwinFtpOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _options = options;
        }

        public byte[] FetchSchedule()
        {
            throw new NotImplementedException();
        }
    }

    public class DarwinFtpOptions : IDarwinScheduleFetcherOptions
    {
        public string DarwinFtpHost { get; set; }
        public string DarwinFtpUsername { get; set; }
        public string DarwinFtpPassword { get; set; }
        public string DarwinScheduleFileSuffix { get; set; }
    }
}