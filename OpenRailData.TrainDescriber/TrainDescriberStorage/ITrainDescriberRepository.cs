using System.Threading.Tasks;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberStorage
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