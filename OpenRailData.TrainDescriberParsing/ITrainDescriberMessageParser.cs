using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberParsing
{
    public interface ITrainDescriberMessageParser
    {
        string DescriberMessageType { get; }

        ITrainDescriberMessage ParseDescriberMessage(string message);
    }
}