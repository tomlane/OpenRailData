using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class ChangeOfIdentityMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0007";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}