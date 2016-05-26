using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberContextFactory : IDbContextFactory<TrainDescriberContext>
    {
        public TrainDescriberContext Create()
        {
            ITrainDescriberDatabase db = new TrainDescriberDatabase(new ConfigConnectionStringProvider());
            return db.BuildContext() as TrainDescriberContext;
        }
    }
}
