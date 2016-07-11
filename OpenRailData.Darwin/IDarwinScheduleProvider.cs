using System;
using System.Text;
using OpenRailData.Darwin.DataDecompression;
using OpenRailData.Darwin.ScheduleFetching;
using OpenRailData.Darwin.ScheduleParsing;
using OpenRailData.Domain.DarwinSchedule;

namespace OpenRailData.Darwin
{
    public interface IDarwinScheduleProvider
    {
        DarwinSchedule GetSchedule();
    }

    public class DarwinScheduleProvider : IDarwinScheduleProvider
    {
        private readonly IDataDecompressor _dataDecompressor;
        private readonly IDarwinScheduleFetcher _darwinScheduleFetcher;
        private readonly IDarwinScheduleParser _darwinScheduleParser;

        public DarwinScheduleProvider(IDataDecompressor dataDecompressor, IDarwinScheduleFetcher darwinScheduleFetcher, IDarwinScheduleParser darwinScheduleParser)
        {
            if (dataDecompressor == null)
                throw new ArgumentNullException(nameof(dataDecompressor));
            if (darwinScheduleFetcher == null)
                throw new ArgumentNullException(nameof(darwinScheduleFetcher));
            if (darwinScheduleParser == null)
                throw new ArgumentNullException(nameof(darwinScheduleParser));

            _dataDecompressor = dataDecompressor;
            _darwinScheduleFetcher = darwinScheduleFetcher;
            _darwinScheduleParser = darwinScheduleParser;
        }
        public DarwinSchedule GetSchedule()
        {
            var compressedScheduleFile = _darwinScheduleFetcher.FetchSchedule();

            var scheduleFile = _dataDecompressor.Decompress(compressedScheduleFile);

            return _darwinScheduleParser.ParseSchedule(Encoding.UTF8.GetString(scheduleFile));
        }
    }
}