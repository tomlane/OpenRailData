﻿using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleRecordMerger
    {
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);
    }
}