using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing
{
    public interface ITrainMovementMessageParser
    {
        string TrainMovementMessageType { get; set; }

        ITrainMovementMessage ParseMovementMessage(string message);
    }
}