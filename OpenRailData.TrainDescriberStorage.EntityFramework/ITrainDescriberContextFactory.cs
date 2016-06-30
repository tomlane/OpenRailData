using Microsoft.Extensions.Options;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public interface ITrainDescriberContextFactory
    {
        TrainDescriberContext Create(IOptions<TrainDescriberContextOptions> options);
    }
}