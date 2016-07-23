using System;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage.RecordStorageProcessor
{
    public class TiplocDeleteScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public TiplocDeleteScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TD;

        public async Task StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.TiplocRecords.DeleteRecord(record as TiplocRecord);

                await unitOfWork.Complete();
            }
        }
    }
}