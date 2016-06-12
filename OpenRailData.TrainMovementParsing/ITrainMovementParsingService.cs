using System.Collections.Generic;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing
{
    public interface ITrainMovementParsingService
    {
        IEnumerable<ITrainMovementMessage> ParseTrainMovementMessages(IEnumerable<string> messages);
    }
}