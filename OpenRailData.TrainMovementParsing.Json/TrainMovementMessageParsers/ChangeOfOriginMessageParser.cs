using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class ChangeOfOriginMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0006";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}