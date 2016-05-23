using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberParsing
{
    public interface ITrainDescriberMessageParser
    {
        string DescriberMessageType { get; set; }

        ITrainDescriberMessage ParseDescriberMessage(string message);
    }
}