using System;
using OpenRailData.Schedule.Api.ResponseModels;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.Api.Presenters
{
    public static class ScheduleLocationRecordPresenter
    {
        public static ScheduleLocationSearchResponseModel PresentScheduleLocationRecord(ScheduleLocationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            return new ScheduleLocationSearchResponseModel
            {
                WorkingDeparture = record.WorkingDeparture.ToString(),
                PublicArrival = record.PublicArrival.ToString(),
                PublicDeparture = record.PublicDeparture.ToString(),
                WorkingArrival = record.WorkingArrival.ToString(),
                Pass = record.Pass.ToString(),
                Path = record.Path,
                OrderTime = record.OrderTime.ToString(),
                EngineeringAllowance = record.EngineeringAllowance.ToString(),
                Line = record.Line,
                PathingAllowance = record.PathingAllowance.ToString(),
                PerformanceAllowance = record.PerformanceAllowance.ToString(),
                Platform = record.Platform,
                Tiploc = record.Tiploc
            };
        }
    }
}