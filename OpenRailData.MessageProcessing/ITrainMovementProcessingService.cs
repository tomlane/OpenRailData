using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.MessageProcessing
{
    public interface ITrainMovementProcessingService
    {
        Task Process(ITrainMovementMessage message);
        Task Process(IEnumerable<ITrainMovementMessage> messages);
    }
}