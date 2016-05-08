using MongoDB.Bson;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Documents
{
    public class TiplocDocument : IScheduleMongoDbDocument
    {
        public BsonObjectId Id { get; set; }
        public string TiplocCode { get; set; } = string.Empty;
        public string CapitalsIdentification { get; set; } = string.Empty;
        public string Nalco { get; set; } = string.Empty;
        public string Nlc { get; set; } = string.Empty;
        public string TpsDescription { get; set; } = string.Empty;
        public string Stanox { get; set; } = string.Empty;
        public string PoMcbCode { get; set; } = string.Empty;
        public string CrsCode { get; set; } = string.Empty;
        public string CapriDescription { get; set; } = string.Empty;
        public string OldTiploc { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
    }
}