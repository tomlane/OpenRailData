using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementStorageService
    {
        Task Store(IEnumerable<ITrainMovementMessage> messages);
        Task Store(ITrainMovementMessage message);
    }
}