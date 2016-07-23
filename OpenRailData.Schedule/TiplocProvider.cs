using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.Schedule
{
    /// <summary>
    /// Provides a set of methods for accessing Tiploc record data.
    /// </summary>
    public class TiplocProvider : ITiplocProvider
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Creates an instance of the Tiploc provider. 
        /// </summary>
        /// <param name="unitOfWorkFactory">The schedule unit of work factory.</param>
        public TiplocProvider(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Finds a Tiploc record matching the specified criteria.
        /// </summary>
        /// <param name="crs">The crs code to query.</param>
        /// <returns>An instance of <see cref="TiplocRecord"/> which matches the criteria.</returns>
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

        /// <summary>
        /// Finds a Tiploc record matching the specified criteria.
        /// </summary>
        /// <param name="stanox">The stanox code to query.</param>
        /// <returns>An instance of <see cref="TiplocRecord"/> which matches the criteria.</returns>
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

        /// <summary>
        /// Finds the location name for a Tiploc record.
        /// </summary>
        /// <param name="stanox">The stanox code of the Tiploc record to query.</param>
        /// <returns>The location name.</returns>
        /// <remarks>If no location name is available the Tiploc code is returned.</remarks>
        public async Task<string> GetLocationNameByStanox(string stanox)
        {
            if (string.IsNullOrWhiteSpace(stanox))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(stanox));

            List<TiplocRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.TiplocRecords.GetTiplocsByStanox(stanox);
            }

            if (records.Count != 1)
                throw new ArgumentException($"No/Multiple tiploc records found for stanox: {stanox}");

            var tiploc = records.First();

            return !string.IsNullOrWhiteSpace(tiploc.LocationName) ? tiploc.LocationName : tiploc.TiplocCode;
        }

        /// <summary>
        /// Finds the location name for a Tiploc record.
        /// </summary>
        /// <param name="tiplocCode">The Tiploc code of the Tiploc record to query.</param>
        /// <returns>The location name.</returns>
        /// <remarks>If no location name is available the Tiploc code is returned.</remarks>
        public async Task<string> GetLocationNameByTiplocCode(string tiplocCode)
        {
            if (string.IsNullOrWhiteSpace(tiplocCode))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(tiplocCode));

            TiplocRecord record;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                record = await unitOfWork.TiplocRecords.GetTiplocByTiplocCode(tiplocCode);
            }

            if (record == null)
                throw new ArgumentException($"No Tiploc record found with Tiploc code: {tiplocCode}");
            
            return !string.IsNullOrWhiteSpace(record.LocationName) ? record.LocationName : record.TiplocCode;
        }
    }
}