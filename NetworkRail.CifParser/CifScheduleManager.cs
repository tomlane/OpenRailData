using System;
using System.Collections.Generic;
using System.IO;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleManager : IScheduleManager
    {
        private readonly ICifRecordParser _cifRecordParser;

        public CifScheduleManager(ICifRecordParser cifRecordParser)
        {
            if (cifRecordParser == null)
                throw new ArgumentNullException(nameof(cifRecordParser));

            _cifRecordParser = cifRecordParser;
        }

        public CifScheduleEntityCollection ParseScheduleEntites(Stream scheduleStream)
        {
            if (scheduleStream == null)
                throw new ArgumentNullException(nameof(scheduleStream));

            var scheduleEntites = new CifScheduleEntityCollection
            {
                AssociationRecords = new List<AssociationRecord>(),
                ScheduleRecords = new List<ScheduleRecord>(),
                TiplocDeleteRecords = new List<TiplocDeleteRecord>(),
                TiplocInsertAmendRecords = new List<TiplocInsertAmendRecord>()
            };

            ScheduleRecord scheduleRecord = null;

            using (BufferedStream bs = new BufferedStream(scheduleStream))
            using (StreamReader sr = new StreamReader(bs))
            {
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    var parsedRecord = _cifRecordParser.ParseRecord(record);

                    switch (parsedRecord.RecordIdentity)
                    {
                        case CifRecordType.Header:
                            scheduleEntites.HeaderRecord = parsedRecord as HeaderRecord;
                            break;
                        case CifRecordType.TiplocInsert:
                        case CifRecordType.TiplocAmend:
                            scheduleEntites.TiplocInsertAmendRecords.Add(parsedRecord as TiplocInsertAmendRecord);
                            break;
                        case CifRecordType.TiplocDelete:
                            scheduleEntites.TiplocDeleteRecords.Add(parsedRecord as TiplocDeleteRecord);
                            break;
                        case CifRecordType.Association:
                            scheduleEntites.AssociationRecords.Add(parsedRecord as AssociationRecord);
                            break;
                        case CifRecordType.EndOfFile:
                            break;

                        case CifRecordType.BasicSchedule:
                            if (scheduleRecord != null)
                            {
                                scheduleEntites.ScheduleRecords.Add(scheduleRecord);
                                scheduleRecord = null;
                            }

                            scheduleRecord = new ScheduleRecord
                            {
                                Schedule = parsedRecord as BasicScheduleRecord,
                                LocationRecords = new List<ICifRecord>()
                            };
                            break;
                        case CifRecordType.BasicScheduleExtraDetails:
                            scheduleRecord?.Schedule.MergeExtraScheduleDetails(parsedRecord as BasicScheduleExtraDetailsRecord);
                            break;
                        case CifRecordType.Location:
                            scheduleRecord?.LocationRecords.Add(parsedRecord as LocationRecord);
                            break;
                        case CifRecordType.ChangesEnRoute:
                            scheduleRecord?.LocationRecords.Add(parsedRecord as ChangesEnRouteRecord);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return scheduleEntites;
        }

        public void SaveScheduleEntities(CifScheduleEntityCollection entites)
        {
            throw new NotImplementedException();
        }
    }
}