namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public interface ITrainDescriberContextFactory
    {
        TrainDescriberContext Create();
    }
}