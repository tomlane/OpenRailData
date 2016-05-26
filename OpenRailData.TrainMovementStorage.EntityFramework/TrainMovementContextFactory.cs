using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementContextFactory : IDbContextFactory<TrainMovementContext>
    {
        public TrainMovementContext Create()
        {
            ITrainMovementDatabase db = new TrainMovementDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as TrainMovementContext;
        }
    }
}
