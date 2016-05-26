using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ISignalMessageRepository
    {
        void InsertRecord(SignalMessage record);
        void AmendRecord(SignalMessage record);
        void DeleteRecord(SignalMessage record);

        Task InsertRecordAsync(SignalMessage record);
        Task InsertMultipleRecordsAsync(IEnumerable<SignalMessage> records);
        Task AmendRecordAsync(SignalMessage record);
        Task DeleteRecordAsync(SignalMessage record);
    }
}