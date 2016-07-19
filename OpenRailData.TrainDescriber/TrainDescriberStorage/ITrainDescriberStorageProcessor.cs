using System.Threading.Tasks;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberStorage
{
    public interface ITrainDescriberStorageProcessor
    {
        TrainDescriberMessageType MessageType { get; }

        Task ProcessMessage(ITrainDescriberMessage message);
    }
}