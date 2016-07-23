using System;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage.RecordStorageProcessor
{
    public class TiplocAmendScheduleRecordStorageProcessor : IScheduleRecordStorageProcessor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public TiplocAmendScheduleRecordStorageProcessor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ScheduleRecordType RecordKey { get; } = ScheduleRecordType.TA;

        public async Task StoreRecord(IScheduleRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                await unitOfWork.TiplocRecords.AmendRecord(record as TiplocRecord);

                await unitOfWork.Complete();
            }
        }
    }
}