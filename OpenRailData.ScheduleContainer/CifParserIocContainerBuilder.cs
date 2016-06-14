using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using OpenRailData.BerthStepData;
using OpenRailData.Configuration;
using OpenRailData.DataFetcher;
using OpenRailData.Modules.ScheduleFetching.Cif;
using OpenRailData.Modules.ScheduleParsing.Cif;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.Modules.ScheduleStorage.EntityFramework;
using OpenRailData.Modules.ScheduleStorage.MongoDb;
using OpenRailData.Modules.ScheduleStorageService.RecordStorageProcessor;
using OpenRailData.Modules.ScheduleValidation;
using OpenRailData.ScheduleFetching;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.PropertyParsers;
using OpenRailData.ScheduleStorage;
using OpenRailData.ScheduleValidation;
using ScheduleUnitOfWork = OpenRailData.Modules.ScheduleStorage.MongoDb.UnitOfWork.ScheduleUnitOfWork;
using ScheduleUnitOfWorkFactory = OpenRailData.Modules.ScheduleStorage.MongoDb.UnitOfWork.ScheduleUnitOfWorkFactory;

namespace OpenRailData.ScheduleContainer
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IBerthStepDataProvider, BerthStepDataProvider>();
            
            container.RegisterType<IDataFileFetcher, WebDataFileFetcher>();
            container.RegisterType<IDataFileDecompressor, GzipDataFileDecompressor>();

            container.RegisterType<IScheduleRecordStorageService, MongoDbBulkCreateStorageService>();
            
            container.RegisterType<IScheduleFetchingService, FileScheduleFetchingService>();

            container.RegisterType<IScheduleFileRecordExtractor, ScheduleFileRecordExtractor>();
            container.RegisterType<IScheduleRecordMerger, CifScheduleRecordMerger>();

            container.RegisterType<IFetchScheduleUrlProvider, CifFetchScheduleUrlProvider>();
            container.RegisterType<IConfigManager, AppSettingsConfigManager>();
            

            
            
            return container;
        }
    }
}