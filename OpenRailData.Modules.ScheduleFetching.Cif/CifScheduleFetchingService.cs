using System;
using System.Collections.Generic;
using OpenRailData.ScheduleFetching;

namespace OpenRailData.Modules.ScheduleFetching.Cif
{
    public class CifScheduleFetchingService : IScheduleFetchingService
    {
        private readonly IFetchScheduleUrlProvider _urlProvider;
        private readonly IScheduleFileRecordExtractor _scheduleFileRecordExtractor;
        private readonly IScheduleFileFetcher _scheduleFileFetcher;

        private byte[] _cachedScheduleFile;

        public CifScheduleFetchingService(IFetchScheduleUrlProvider urlProvider, IScheduleFileRecordExtractor scheduleFileRecordExtractor, IScheduleFileFetcher scheduleFileFetcher)
        {
            if (urlProvider == null)
                throw new ArgumentNullException(nameof(urlProvider));
            if (scheduleFileRecordExtractor == null)
                throw new ArgumentNullException(nameof(scheduleFileRecordExtractor));
            if (scheduleFileFetcher == null)
                throw new ArgumentNullException(nameof(scheduleFileFetcher));

            _urlProvider = urlProvider;
            _scheduleFileRecordExtractor = scheduleFileRecordExtractor;
            _scheduleFileFetcher = scheduleFileFetcher;
        }

        public IEnumerable<string> FetchSchedule(ScheduleType scheduleType, bool useCachedFile = true)
        {
            if (useCachedFile && _cachedScheduleFile != null)
                return _scheduleFileRecordExtractor.ExtractScheduleFileRecords(_cachedScheduleFile);

            string scheduleUrl;

            switch (scheduleType)
            {
                case ScheduleType.Full:
                    scheduleUrl = _urlProvider.GetWeeklyScheduleUrl();
                    break;
                    case ScheduleType.Update:
                    scheduleUrl = _urlProvider.GetDailyUpdateScheduleUrl();
                    break;
                default:
                    throw new ArgumentException($"Unknown schedule type {scheduleType}");
            }

            _cachedScheduleFile = _scheduleFileFetcher.FetchScheduleFileFromUrl(scheduleUrl);

            return _scheduleFileRecordExtractor.ExtractScheduleFileRecords(_cachedScheduleFile);
        }

        public void ClearCache()
        {
            _cachedScheduleFile = null;
        }
    }
}