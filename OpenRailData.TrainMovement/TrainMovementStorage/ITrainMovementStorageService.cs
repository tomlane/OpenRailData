using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementStorage
{
    public interface ITrainMovementStorageService
    {
        Task Store(IEnumerable<ITrainMovementMessage> messages);
        Task Store(ITrainMovementMessage message);
    }
}