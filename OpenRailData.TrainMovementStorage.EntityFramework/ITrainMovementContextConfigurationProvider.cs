namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContextConfigurationProvider
    {
        TrainMovementContextConfiguration GetConfiguration();
    }
}