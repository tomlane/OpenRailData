using System;
using System.Collections.Generic;
using OpenRailData.ScheduleFetching;

namespace OpenRailData.Modules.ScheduleFetching.Cif
{
    public class CifScheduleFetchingService : IScheduleFetchingService
    {
        private readonly IFetchScheduleUrlProvider _urlProvider;
        private readonly IScheduleFileRecordExtractor _scheduleFileRecordExtractor;
        private readonly IDataFileFetcher _dataFileFetcher;
        private readonly IDataFileDecompressor _dataFileDecompressor;

        private byte[] _cachedScheduleFile;

        public CifScheduleFetchingService(IFetchScheduleUrlProvider urlProvider, IScheduleFileRecordExtractor scheduleFileRecordExtractor, IDataFileFetcher dataFileFetcher, IDataFileDecompressor dataFileDecompressor)
        {
            if (urlProvider == null)
                throw new ArgumentNullException(nameof(urlProvider));
            if (scheduleFileRecordExtractor == null)
                throw new ArgumentNullException(nameof(scheduleFileRecordExtractor));
            if (dataFileFetcher == null)
                throw new ArgumentNullException(nameof(dataFileFetcher));
            if (dataFileDecompressor == null)
                throw new ArgumentNullException(nameof(dataFileDecompressor));

            _urlProvider = urlProvider;
            _scheduleFileRecordExtractor = scheduleFileRecordExtractor;
            _dataFileFetcher = dataFileFetcher;
            _dataFileDecompressor = dataFileDecompressor;
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

            _cachedScheduleFile = _dataFileDecompressor.DecompressDataFile(_dataFileFetcher.FetchDataFile(scheduleUrl));

            return _scheduleFileRecordExtractor.ExtractScheduleFileRecords(_cachedScheduleFile);
        }

        public void ClearCache()
        {
            _cachedScheduleFile = null;
        }
    }
}