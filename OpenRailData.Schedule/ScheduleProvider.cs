using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.Schedule
{
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public ScheduleProvider(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<ScheduleRecord> GetScheduleRecord(string trainUid, DateTime startDate)
        {
            if (string.IsNullOrWhiteSpace(trainUid))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(trainUid));

            IEnumerable<ScheduleRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.ScheduleRecords.GetScheduleRecords(trainUid, startDate);
            }

            return records.OrderByDescending(x => x.StpIndicator).FirstOrDefault();
        }
    }
}