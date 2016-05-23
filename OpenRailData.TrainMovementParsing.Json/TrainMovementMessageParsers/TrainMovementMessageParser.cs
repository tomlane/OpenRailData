using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainMovementMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0003";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}