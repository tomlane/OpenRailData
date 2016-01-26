using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NetworkRail.CifParser.RecordParsers;
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

        public IList<ICifRecord> ParseScheduleEntites(Stream scheduleStream)
        {
            var recordList = new List<ICifRecord>();

            using (BufferedStream bs = new BufferedStream(scheduleStream))
            using (StreamReader sr = new StreamReader(bs))
            {
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    if (record.Length != 80)
                        throw new ArgumentOutOfRangeException($"The CIF record must have a length of 80 characters. Current record length: {record.Length}");

                    string recordType = record.Substring(0, 2);

                    if (recordType == "ZZ")
                    {
                        recordList.Add(new EndOfFileRecord());
                        break;
                    }

                    ICifRecordParser parser;

                    try
                    {
                        parser = _cifRecordParsers[recordType];
                    }
                    catch (KeyNotFoundException exception)
                    {
                        throw new ArgumentException($"No parser found for record type {recordType}", exception);
                    }

                    recordList.Add(parser.ParseRecord(record));
                }
            }

            return recordList;
        }

        public IList<ICifRecord> ParseScheduleEntites(string scheduleFilePath)
        {
            if (string.IsNullOrWhiteSpace(scheduleFilePath))
                throw new ArgumentNullException(nameof(scheduleFilePath));

            var recordsToParse = _scheduleReader.ReadSchedule(scheduleFilePath);

            return _scheduleParser.ParseScheduleFile(recordsToParse);
        }

        public void SaveScheduleEntities(IList<ICifRecord> entites)
        {
            throw new NotImplementedException();
        }
    }
}