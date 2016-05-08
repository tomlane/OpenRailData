using MongoDB.Bson;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Documents
{
    public interface IScheduleMongoDbDocument
    {
        BsonObjectId Id { get; set; }
    }
}