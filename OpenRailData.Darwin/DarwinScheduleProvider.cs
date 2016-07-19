using System;
using System.Text;
using OpenRailData.Darwin.DataDecompression;
using OpenRailData.Darwin.DataFetching;
using OpenRailData.Darwin.Entites.Schedule;
using OpenRailData.Darwin.ScheduleParsing;

namespace OpenRailData.Darwin
{
    public class DarwinScheduleProvider : IDarwinScheduleProvider
    {
        private readonly IDataDecompressor _dataDecompressor;
        private readonly IDarwinDataFileFetcher _darwinDataFileFetcher;
        private readonly IDarwinScheduleParser _darwinScheduleParser;

        public DarwinScheduleProvider(IDataDecompressor dataDecompressor, IDarwinDataFileFetcher darwinDataFileFetcher, IDarwinScheduleParser darwinScheduleParser)
        {
            if (dataDecompressor == null)
                throw new ArgumentNullException(nameof(dataDecompressor));
            if (darwinDataFileFetcher == null)
                throw new ArgumentNullException(nameof(darwinDataFileFetcher));
            if (darwinScheduleParser == null)
                throw new ArgumentNullException(nameof(darwinScheduleParser));

            _dataDecompressor = dataDecompressor;
            _darwinDataFileFetcher = darwinDataFileFetcher;
            _darwinScheduleParser = darwinScheduleParser;
        }
        public DarwinSchedule GetSchedule()
        {
            var compressedScheduleFile = _darwinDataFileFetcher.FetchFile(@"C:\Users\Tom\OneDrive\RailData\Darwin Schedule\20160711020806_v8.xml.gz");

            var scheduleFile = _dataDecompressor.Decompress(compressedScheduleFile);

            return _darwinScheduleParser.ParseSchedule(Encoding.UTF8.GetString(scheduleFile));
        }
    }
}