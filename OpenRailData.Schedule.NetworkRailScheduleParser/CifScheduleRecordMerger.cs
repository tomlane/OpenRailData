using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

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
                        scheduleEntites.Add(record as HeaderRecord);
                        break;
                    case ScheduleRecordType.TI:
                    case ScheduleRecordType.TA:
                    case ScheduleRecordType.TD:
                        scheduleEntites.Add(record as TiplocDeleteRecord);
                        break;
                    case ScheduleRecordType.AAN:
                    case ScheduleRecordType.AAR:
                    case ScheduleRecordType.AAD:
                        scheduleEntites.Add(record as AssociationRecord);
                        break;
                    case ScheduleRecordType.ZZ:
                        break;
                    case ScheduleRecordType.BSN:
                    case ScheduleRecordType.BSR:
                    case ScheduleRecordType.BSD:
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
                    case ScheduleRecordType.BX:
                        scheduleRecord?.Schedule.MergeExtraScheduleDetails(record as BasicScheduleExtraDetailsRecord);
                        break;
                    case ScheduleRecordType.LO:
                        scheduleRecord?.LocationRecords.Add(record as OriginLocationRecord);
                        break;
                    case ScheduleRecordType.LI:
                        scheduleRecord?.LocationRecords.Add(record as IntermediateLocationRecord);
                        break;
                    case ScheduleRecordType.LT:
                        scheduleRecord?.LocationRecords.Add(record as TerminatingLocationRecord);
                        break;
                    case ScheduleRecordType.CR:
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