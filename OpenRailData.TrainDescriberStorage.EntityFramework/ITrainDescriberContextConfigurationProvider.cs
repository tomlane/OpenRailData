namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public interface ITrainDescriberContextConfigurationProvider
    {
        TrainDescriberContextConfiguration GetConfiguration();
    }
}