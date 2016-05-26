namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementDatabase
    {
        ITrainMovementContext DbContext { get; set; }
        ITrainMovementContext BuildContext();
    }
}
