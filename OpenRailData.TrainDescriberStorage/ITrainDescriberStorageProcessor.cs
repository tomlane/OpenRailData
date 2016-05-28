using System.Threading.Tasks;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberStorageProcessor
    {
        TrainDescriberMessageType MessageType { get; }

        Task ProcessMessage(ITrainDescriberMessage message);
    }
}