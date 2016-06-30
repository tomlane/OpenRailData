using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberContextFactory : ITrainDescriberContextFactory
    {
        public TrainDescriberContext Create(IOptions<TrainDescriberContextOptions> options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainDescriberContext>();

            optionsBuilder.UseSqlServer(options.Value.ConnectionString);

            return new TrainDescriberContext(optionsBuilder.Options);
        }
    }
}
