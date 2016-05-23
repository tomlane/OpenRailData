using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainActivationMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0001";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}