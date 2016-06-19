using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif
{
    public class CifScheduleRecordMerger : IScheduleRecordMerger
    {
        /// <summary>
        /// Takes a set of parsed CIF records and merges where required.
        /// </summary>
        /// <param name="scheduleRecords">The set of schedule records.</param>
        /// <returns>A merged set of schedule records.</returns>
        /// <remarks>Not my finest code.</remarks>
        public IEnumerable<IScheduleRecord> MergeScheduleRecords(IEnumerable<IScheduleRecord> scheduleRecords)
        {
            if (scheduleRecords == null || !scheduleRecords.Any())
                throw new ArgumentNullException(nameof(scheduleRecords));

            var scheduleEntities = new List<IScheduleRecord>();

            ScheduleRecord scheduleRecord = null;

            foreach (var record in scheduleRecords)
            {
                switch (record.RecordIdentity)
                {
                    case ScheduleRecordType.HD:
                        scheduleEntities.Add(record);
                        break;
                    case ScheduleRecordType.TI:
                    case ScheduleRecordType.TA:
                    case ScheduleRecordType.TD:
                        scheduleEntities.Add(record);
                        break;
                    case ScheduleRecordType.AAN:
                    case ScheduleRecordType.AAR:
                    case ScheduleRecordType.AAD:
                        scheduleEntities.Add(record);
                        break;
                    case ScheduleRecordType.BSN:
                    case ScheduleRecordType.BSR:
                    case ScheduleRecordType.BSD:
                        if (scheduleRecord != null)
                        {
                            scheduleEntities.Add(scheduleRecord);
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

            return scheduleEntities;
        }
    }
}