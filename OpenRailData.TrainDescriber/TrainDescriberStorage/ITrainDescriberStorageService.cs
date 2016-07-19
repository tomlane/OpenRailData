using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberStorage
{
    public interface ITrainDescriberStorageService
    {
        Task StoreDescriberMessages(IEnumerable<ITrainDescriberMessage> messages);
    }
}