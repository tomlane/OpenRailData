using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberParsing
{
    public interface ITrainDescriberMessageParser
    {
        string DescriberMessageType { get; }

        ITrainDescriberMessage ParseDescriberMessage(string message);
    }
}