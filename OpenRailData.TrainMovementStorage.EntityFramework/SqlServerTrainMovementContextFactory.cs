using Microsoft.EntityFrameworkCore;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class SqlServerTrainMovementContextFactory : ITrainMovementContextFactory
    {
        private readonly TrainMovementContextConfiguration _configuration;

        public SqlServerTrainMovementContextFactory(ITrainMovementContextConfigurationProvider configurationProvider)
        {
            _configuration = configurationProvider.GetConfiguration();
        }

        public TrainMovementContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainMovementContext>();

            optionsBuilder.UseSqlServer(_configuration.ConnectionString);

            return new TrainMovementContext(optionsBuilder.Options);
        }
    }
}
