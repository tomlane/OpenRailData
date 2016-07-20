namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class StaticTrainMovementContextConfigurationProvider : ITrainMovementContextConfigurationProvider
    {
        public TrainMovementContextConfiguration GetConfiguration()
        {
            return new TrainMovementContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}