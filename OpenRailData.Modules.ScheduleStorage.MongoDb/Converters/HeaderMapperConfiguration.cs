using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    internal class HeaderMapperConfiguration
    {
        internal static IMapper RecordToDocument()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HeaderRecord, HeaderDocument>());

            return config.CreateMapper();
        }

        internal static IMapper DocumentToRecord()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HeaderRecord, HeaderDocument>());

            return config.CreateMapper();
        }
    }
}