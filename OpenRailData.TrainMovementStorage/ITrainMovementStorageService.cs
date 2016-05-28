using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementStorageService
    {
        Task StoreTrainMovementMessages(IEnumerable<ITrainMovementMessage> messages);
    }
}