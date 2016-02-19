using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;
using OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class ScheduleRecordSetParser : IScheduleRecordSetParser
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;
        private readonly Dictionary<string, IScheduleRecordParser> _cifRecordParsers;
        private readonly ILog Logger = LogManager.GetLogger("Schedule.Util.CifRecordSetParser");
        
        public ScheduleRecordSetParser(IScheduleRecordParser[] recordParsers, IDbContextFactory<ScheduleContext> contextFactory)
        {
            
            if (recordParsers == null)
                throw new ArgumentNullException(nameof(recordParsers));
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _cifRecordParsers = recordParsers.ToDictionary(x => x.RecordKey, x => x);
            _contextFactory = contextFactory;
        }

        public IEnumerable<IScheduleRecord> ParseScheduleRecordSet(IEnumerable<string> recordsToParse)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Starting to parse Schedule record set.");

            if (recordsToParse == null)
                throw new ArgumentNullException(nameof(recordsToParse));

            var resultList = new List<IScheduleRecord>();

            foreach (var record in recordsToParse)
            {
                var recordType = record.Substring(0, 2);

                IScheduleRecordParser parser;

                try
                {
                    parser = _cifRecordParsers[recordType];
                }
                catch (KeyNotFoundException exception)
                {
                    throw new ArgumentException($"No parser found for record type {recordType}", exception);
                }

                var result = parser.ParseRecord(record);

                if (result.RecordIdentity == ScheduleRecordType.HD)
                    ValidateHeaderRecord(result as HeaderRecord);

                resultList.Add(result);
            }

            if (Logger.IsInfoEnabled)
                Logger.Info("Finished parsing schedule record set.");

            return resultList;
        }

        private void ValidateHeaderRecord(HeaderRecord headerRecord)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Validating Schedule Header Record.");

            if (headerRecord == null)
                throw new ArgumentNullException(nameof(headerRecord));

            using (var unitOfWork = new ScheduleUnitOfWork(_contextFactory.Create()))
            {
                var previousUpdate = unitOfWork.HeaderRecords.GetRecentUpdates().FirstOrDefault();

                if (headerRecord.DateOfExtract <= previousUpdate.DateOfExtract)
                    throw new InvalidOperationException(
                        $"The schedule file is out of order. Previous update date: {previousUpdate.DateOfExtract}. Attempted update date: {headerRecord.DateOfExtract}");

                if (previousUpdate.ExtractUpdateType != ExtractUpdateType.U) return;

                if (previousUpdate.CurrentFileRef != headerRecord.LastFileRef)
                    throw new InvalidOperationException($"The schedule file is out of order. Last file reference: {previousUpdate.CurrentFileRef}. Expected Last file reference: {headerRecord.LastFileRef}");
            }

            if (Logger.IsInfoEnabled)
                Logger.Info("Finished validating Schedule Header Record. Header is valid.");
        }
    }
}