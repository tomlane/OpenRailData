using System.Collections.Generic;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementParsing
{
    public interface ITrainMovementParsingService
    {
        IEnumerable<ITrainMovementMessage> ParseTrainMovementMessages(IEnumerable<string> messages);
    }
}