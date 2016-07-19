using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleValidation
{
    public interface IScheduleRecordValidator
    {
        /// <summary>
        /// Runs a schedule record through a set of validation rules, throws when validation fails.
        /// </summary>
        /// <param name="record">The schedule record to validate.</param>
        void ValidateRecord(IScheduleRecord record);
    }
}