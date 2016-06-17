using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using OpenRailData.Configuration;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.UnitOfWork;
using OpenRailData.Modules.ScheduleStorageService;
using OpenRailData.Modules.ScheduleStorageService.RecordStorageProcessor;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public static class EntityFrameworkScheduleStorageContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleRecordStorageService, ScheduleRecordStorageService>();

            container.RegisterType<IScheduleRecordStorageProcessor, AssociationAmendScheduleRecordStorageProcessor>("AssociationAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, AssociationDeleteScheduleRecordStorageProcessor>("AssociationDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, AssociationInsertScheduleRecordStorageProcessor>("AssociationInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleAmendScheduleRecordStorageProcessor>("ScheduleAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleDeleteScheduleRecordStorageProcessor>("ScheduleDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleInsertScheduleRecordStorageProcessor>("ScheduleInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocAmendScheduleRecordStorageProcessor>("TiplocAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocDeleteScheduleRecordStorageProcessor>("TiplocDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocInsertScheduleRecordStorageProcessor>("TiplocInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, HeaderScheduleRecordStorageProcessor>("HeaderScheduleRecordStorageProcessor");

            container.RegisterType<IScheduleUnitOfWorkFactory, ScheduleUnitOfWorkFactory>();
            container.RegisterType<IScheduleUnitOfWork, ScheduleUnitOfWork>();

            container.RegisterType<IDbContextFactory<ScheduleContext>, ScheduleContextFactory>();
            container.RegisterType<IScheduleContext, ScheduleContext>();

            container.RegisterType<IConnectionStringProvider, ConfigConnectionStringProvider>();

            container.RegisterType<IHeaderRecordRepository, HeaderRecordRepository>();
            container.RegisterType<IAssociationRecordRepository, AssociationRecordRepository>();
            container.RegisterType<IScheduleRecordRepository, ScheduleRecordRepository>();
            container.RegisterType<ITiplocRecordRepository, TiplocRecordRepository>();

            return container;
        }
    }
}