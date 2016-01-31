using System;
using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleManager : IScheduleManager
    {
        private readonly IScheduleReader _scheduleReader;
        private readonly IScheduleParser _scheduleParser;

        public CifScheduleManager(IScheduleReader scheduleReader, IScheduleParser scheduleParser)
        {
            if (scheduleReader == null)
                throw new ArgumentNullException(nameof(scheduleReader));
            if (scheduleParser == null)
                throw new ArgumentNullException(nameof(scheduleParser));

            _scheduleReader = scheduleReader;
            _scheduleParser = scheduleParser;
        }

        public IList<IScheduleRecord> ParseScheduleEntites(string scheduleFilePath)
        {
            if (string.IsNullOrWhiteSpace(scheduleFilePath))
                throw new ArgumentNullException(nameof(scheduleFilePath));

            var recordsToParse = _scheduleReader.ReadSchedule(scheduleFilePath);

            return _scheduleParser.ParseScheduleFile(recordsToParse);
        }

        public void SaveScheduleEntities(IList<IScheduleRecord> entites)
        {
            throw new NotImplementedException();
        }
    }
}