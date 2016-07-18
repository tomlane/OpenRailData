using Microsoft.EntityFrameworkCore;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberContextFactory : ITrainDescriberContextFactory
    {
        private readonly TrainDescriberContextConfiguration _configuration;

        public TrainDescriberContextFactory(ITrainDescriberContextConfigurationProvider configurationProvider)
        {
            _configuration = configurationProvider.GetConfiguration();
        }

        public TrainDescriberContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainDescriberContext>();

            optionsBuilder.UseSqlServer(_configuration.ConnectionString);

            return new TrainDescriberContext(optionsBuilder.Options);
        }
    }
}
