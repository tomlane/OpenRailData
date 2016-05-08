using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    internal class TiplocMapperConfiguration
    {
        internal static IMapper RecordToDocument()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TiplocRecord, TiplocDocument>());

            return config.CreateMapper();
        }

        internal static IMapper DocumentToRecord()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TiplocDocument, TiplocRecord>());

            return config.CreateMapper();
        }
    }
}