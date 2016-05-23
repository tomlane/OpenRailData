using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing
{
    public interface ITrainMovementMessageParser
    {
        string TrainMovementMessageType { get; }

        ITrainMovementMessage ParseMovementMessage(string message);
    }
}