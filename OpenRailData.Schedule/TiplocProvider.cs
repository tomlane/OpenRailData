using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Schedule
{
    public class TiplocProvider : ITiplocProvider
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public TiplocProvider(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<TiplocRecord> GetTiplocByCrs(string crs)
        {
            if (string.IsNullOrWhiteSpace(crs))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(crs));

            List<TiplocRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.TiplocRecords.GetTiplocsByCrs(crs);
            }

            if (records.Count != 1)
                throw new ArgumentException($"No/Multiple tiploc records found for crs: {crs}.");

            return records.First();
        }

        public async Task<TiplocRecord> GetTiplocByStanox(string stanox)
        {
            if (string.IsNullOrWhiteSpace(stanox))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(stanox));

            List<TiplocRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.TiplocRecords.GetTiplocsByStanox(stanox);
            }

            if (records.Count != 1)
                throw new ArgumentException($"No/Multiple tiploc records found for stanox: {stanox}.");

            return records.First();

        }
    }
}