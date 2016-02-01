using System;
using System.Collections.Generic;
using System.Linq;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleRecordMerger : IScheduleRecordMerger
    {
        public IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            var scheduleEntites = new List<IScheduleRecord>();

            ScheduleRecord scheduleRecord = null;

            foreach (var record in scheduleRecords)
            {
                switch (record.RecordIdentity)
                {
                    case ScheduleRecordType.CifHeader:
                        scheduleEntites.Add(record as HeaderRecord);
                        break;
                    case ScheduleRecordType.TiplocInsert:
                        scheduleEntites.Add(record as TiplocInsertRecord);
                        break;
                    case ScheduleRecordType.TiplocAmend:
                        scheduleEntites.Add(record as TiplocAmendRecord);
                        break;
                    case ScheduleRecordType.TiplocDelete:
                        scheduleEntites.Add(record as TiplocDeleteRecord);
                        break;
                    case ScheduleRecordType.Association:
                        scheduleEntites.Add(record as AssociationRecord);
                        break;
                    case ScheduleRecordType.EndOfFile:
                        break;

                    case ScheduleRecordType.BasicSchedule:
                        if (scheduleRecord != null)
                        {
                            scheduleEntites.Add(scheduleRecord);
                            scheduleRecord = null;
                        }

                        scheduleRecord = new ScheduleRecord
                        {
                            Schedule = record as BasicScheduleRecord
                        };
                        break;
                    case ScheduleRecordType.BasicScheduleExtraDetails:
                        scheduleRecord?.Schedule.MergeExtraScheduleDetails(record as BasicScheduleExtraDetailsRecord);
                        break;
                    case ScheduleRecordType.OriginLocation:
                        scheduleRecord?.LocationRecords.Add(record as OriginLocationRecord);
                        break;
                    case ScheduleRecordType.IntermediateLocation:
                        scheduleRecord?.LocationRecords.Add(record as IntermediateLocationRecord);
                        break;
                    case ScheduleRecordType.TerminatingLocation:
                        scheduleRecord?.LocationRecords.Add(record as TerminatingLocationRecord);
                        break;
                    case ScheduleRecordType.ChangesEnRoute:
                        scheduleRecord?.LocationRecords.Add(record as ChangesEnRouteRecord);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return scheduleEntites;
        }
    }
}