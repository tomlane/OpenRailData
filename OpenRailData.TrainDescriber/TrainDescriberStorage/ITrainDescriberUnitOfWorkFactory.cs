namespace OpenRailData.TrainDescriber.TrainDescriberStorage
{
    public interface ITrainDescriberUnitOfWorkFactory
    {
        ITrainDescriberUnitOfWork Create();
    }
}