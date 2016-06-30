using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class SqlServerTrainMovementContextFactory : ITrainMovementContextFactory
    {
        public TrainMovementContext Create(IOptions<TrainMovementContextOptions> options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainMovementContext>();

            optionsBuilder.UseSqlServer(options.Value.ConnectionString);

            return new TrainMovementContext(optionsBuilder.Options);
        }
    }
}
