using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
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
                    case ScheduleRecordType.HD:
                        scheduleEntites.Add(record);
                        break;
                    case ScheduleRecordType.TI:
                    case ScheduleRecordType.TA:
                    case ScheduleRecordType.TD:
                        scheduleEntites.Add(record);
                        break;
                    case ScheduleRecordType.AAN:
                    case ScheduleRecordType.AAR:
                    case ScheduleRecordType.AAD:
                        scheduleEntites.Add(record);
                        break;
                    case ScheduleRecordType.BSN:
                    case ScheduleRecordType.BSR:
                    case ScheduleRecordType.BSD:
                        if (scheduleRecord != null)
                        {
                            scheduleEntites.Add(scheduleRecord);
                            scheduleRecord = null;
                        }

                        scheduleRecord = record as ScheduleRecord;
                        break;
                    case ScheduleRecordType.BX:
                        scheduleRecord?.MergeExtraScheduleDetails(record as BasicScheduleExtraDetailsRecord);
                        break;
                    case ScheduleRecordType.LO:
                    case ScheduleRecordType.LI:
                    case ScheduleRecordType.LT:
                        scheduleRecord?.ScheduleLocations.Add(record as ScheduleLocationRecord);
                        break;
                    case ScheduleRecordType.CR:
                    case ScheduleRecordType.ZZ:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return scheduleEntites;
        }
    }
}