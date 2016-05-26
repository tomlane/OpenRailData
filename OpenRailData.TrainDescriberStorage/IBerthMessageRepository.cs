using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface IBerthMessageRepository
    {
        void InsertRecord(BerthMessage record);
        void AmendRecord(BerthMessage record);
        void DeleteRecord(BerthMessage record);

        Task InsertRecordAsync(BerthMessage record);
        Task InsertMultipleRecordsAsync(IEnumerable<BerthMessage> records);
        Task AmendRecordAsync(BerthMessage record);
        Task DeleteRecordAsync(BerthMessage record);
    }
}