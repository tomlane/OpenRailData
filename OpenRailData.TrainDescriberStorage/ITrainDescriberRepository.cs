using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberRepository<T> where T : ITrainDescriberMessage
    {
        void InsertRecord(T record);
        void AmendRecord(T record);
        void DeleteRecord(T record);

        Task InsertRecordAsync(T record);
        Task AmendRecordAsync(T record);
        Task DeleteRecordAsync(T record);
    }
}