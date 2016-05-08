using System;
using MongoDB.Bson;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Documents
{
    public class ScheduleLocationDocument : IScheduleMongoDbDocument
    {
        public BsonObjectId Id { get; set; }
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { private get; set; } = string.Empty;
        public string Location => $"{Tiploc}{TiplocSuffix}";
        public string WorkingArrival { get; set; } = string.Empty;
        public string PublicArrival { get; set; } = string.Empty;
        public string WorkingDeparture { get; set; } = string.Empty;
        public string PublicDeparture { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public TimeSpan EngineeringAllowance { get; set; }
        public TimeSpan PathingAllowance { get; set; }
        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; } = 0;
        public TimeSpan PerformanceAllowance { get; set; }
    }
}