using System.Threading.Tasks;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberStorage
{
    public interface ITrainDescriberRepository<T> where T : ITrainDescriberMessage
    {
        Task InsertRecord(T record);
        Task AmendRecord(T record);
        Task DeleteRecord(T record);
    }
}