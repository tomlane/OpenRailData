using MongoDB.Driver;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb
{
    public interface IMongoDbClientFactory
    {
        IMongoClient Create();
    }
}