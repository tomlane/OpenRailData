using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    internal class ScheduleMapperConfiguration
    {
        internal static IMapper RecordToDocument()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScheduleRecord, ScheduleDocument>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<ScheduleLocationRecord, ScheduleLocationDocument>();
            });

            return config.CreateMapper();
        }

        internal static IMapper DocumentToRecord()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScheduleDocument, ScheduleRecord>();
                cfg.CreateMap<ScheduleLocationDocument, ScheduleLocationRecord>();
            });

            return config.CreateMapper();
        }
    }
}