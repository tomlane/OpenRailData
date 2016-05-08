using System;
using MongoDB.Bson;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Documents
{
    public class HeaderDocument : IScheduleMongoDbDocument
    {
        public BsonObjectId Id { get; set; }
        public string MainFrameIdentity { get; set; } = string.Empty;
        public DateTime DateOfExtract { get; set; }
        public string TimeOfExtract { get; set; } = string.Empty;
        public string CurrentFileRef { get; set; } = string.Empty;
        public string LastFileRef { get; set; } = string.Empty;
        public ExtractUpdateType ExtractUpdateType { get; set; }
        public string CifSoftwareVersion { get; set; } = string.Empty;
        public DateTime UserExtractStartDate { get; set; }
        public DateTime UserExtractEndDate { get; set; }
        public string MainFrameUser { get; set; } = string.Empty;
        public DateTime MainFrameExtractDate { get; set; }
    }
}