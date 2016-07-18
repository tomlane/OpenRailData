namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class StaticTrainDescriberContextConfigurationProvider : ITrainDescriberContextConfigurationProvider
    {
        public TrainDescriberContextConfiguration GetConfiguration()
        {
            return new TrainDescriberContextConfiguration
            {
                ConnectionString = @"Server=localhost\SQLSERVER2016RC1;Initial Catalog=RailDataEngine; Integrated Security=true;"
            };
        }
    }
}