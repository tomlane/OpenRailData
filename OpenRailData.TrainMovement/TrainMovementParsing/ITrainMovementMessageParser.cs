using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementParsing
{
    public interface ITrainMovementMessageParser
    {
        string TrainMovementMessageType { get; }

        ITrainMovementMessage ParseMovementMessage(string message);
    }
}