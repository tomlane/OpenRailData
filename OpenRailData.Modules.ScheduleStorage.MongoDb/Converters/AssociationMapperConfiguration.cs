using AutoMapper;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Converters
{
    internal class AssociationMapperConfiguration
    {
        internal static IMapper RecordToDocument()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AssociationRecord, AssociationDocument>());

            return config.CreateMapper();
        }

        internal static IMapper DocumentToRecord()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AssociationDocument, AssociationRecord>());

            return config.CreateMapper();
        }
    }
}