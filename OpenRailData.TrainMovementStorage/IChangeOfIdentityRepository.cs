using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface IChangeOfIdentityRepository
    {
        void InsertRecord(ChangeOfIdentity record);
        void AmendRecord(ChangeOfIdentity record);
        void DeleteRecord(ChangeOfIdentity record);

        Task InsertRecordAsync(ChangeOfIdentity record);
        Task InsertMultipleRecordsAsync(IEnumerable<ChangeOfIdentity> records);
        Task AmendRecordAsync(ChangeOfIdentity record);
        Task DeleteRecordAsync(ChangeOfIdentity record);
    }
}