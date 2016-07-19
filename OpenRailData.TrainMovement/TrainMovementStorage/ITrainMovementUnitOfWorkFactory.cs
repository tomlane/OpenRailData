namespace OpenRailData.TrainMovement.TrainMovementStorage
{
    public interface ITrainMovementUnitOfWorkFactory
    {
        ITrainMovementUnitOfWork Create();
    }
}