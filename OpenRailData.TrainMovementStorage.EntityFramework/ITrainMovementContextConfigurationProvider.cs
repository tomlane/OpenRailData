namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public interface ITrainMovementContextConfigurationProvider
    {
        TrainMovementContextConfiguration GetConfiguration();
    }

    public class StaticTrainMovementContextConfigurationProvider : ITrainMovementContextConfigurationProvider
    {
        public TrainMovementContextConfiguration GetConfiguration()
        {
            return new TrainMovementContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016RC1;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}