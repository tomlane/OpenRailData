using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.Schedule
{
    /// <summary>
    /// A class providing a set of methods to access schedule records.
    /// </summary>
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Constructs an instance of the schedule provider.
        /// </summary>
        /// <param name="unitOfWorkFactory">The schedule unit of work factory.</param>
        public ScheduleProvider(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }
        
        /// <summary>
        /// Find the schedule record active for the current day.
        /// </summary>
        /// <param name="trainUid">The trainUid for the train/service.</param>
        /// <param name="startDate">The schedule start date.</param>
        /// <returns>A Schedule record. <see cref="ScheduleRecord"/></returns>
        /// <remarks>This method should be used when processing a train activation message from the movements feed.</remarks>
        public async Task<ScheduleRecord> GetScheduleRecord(string trainUid, DateTime startDate)
        {
            if (string.IsNullOrWhiteSpace(trainUid))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(trainUid));

            IEnumerable<ScheduleRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.ScheduleRecords.GetScheduleRecords(trainUid, startDate);
            }

            if (!records.Any())
                throw new ArgumentException("No schedule records found");
            
            return records.OrderByDescending(x => x.StpIndicator).First();
        }

        public async Task<List<ScheduleLocationRecord>> GetScheduleLocationsByTiploc(string tiplocCode)
        {
            if (tiplocCode == null)
                throw new ArgumentNullException(nameof(tiplocCode));

            List<ScheduleLocationRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.ScheduleLocationRecords.GetLocationsByTiploc(tiplocCode);
            }

            return records.OrderBy(x => x.OrderTime.Value.TickOfDay).ToList();
        }
    }
}