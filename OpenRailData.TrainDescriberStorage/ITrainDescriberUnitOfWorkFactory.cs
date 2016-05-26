namespace OpenRailData.TrainDescriberStorage
{
    public interface ITrainDescriberUnitOfWorkFactory
    {
        ITrainDescriberUnitOfWork Create();
    }
}