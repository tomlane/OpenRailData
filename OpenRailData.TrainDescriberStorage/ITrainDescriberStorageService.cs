using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberStorageService
    {
        Task StoreDescriberMessages(IEnumerable<ITrainDescriberMessage> messages);
    }
}