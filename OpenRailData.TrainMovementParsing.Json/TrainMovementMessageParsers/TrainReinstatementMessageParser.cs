using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class TrainReinstatementMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0004";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}