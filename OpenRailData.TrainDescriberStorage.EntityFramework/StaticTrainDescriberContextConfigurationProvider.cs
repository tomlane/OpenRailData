namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class StaticTrainDescriberContextConfigurationProvider : ITrainDescriberContextConfigurationProvider
    {
        public TrainDescriberContextConfiguration GetConfiguration()
        {
            return new TrainDescriberContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}