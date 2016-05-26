namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementsUnitOfWorkFactory
    {
        ITrainMovementsUnitOfWork Create();
    }
}