using System;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers
{
    public class ChangeOfIdentityMessageParser : ITrainMovementMessageParser
    {
        public string TrainMovementMessageType { get; } = "0007";

        public ITrainMovementMessage ParseMovementMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));
            
            throw new System.NotImplementedException();
        }
    }
}