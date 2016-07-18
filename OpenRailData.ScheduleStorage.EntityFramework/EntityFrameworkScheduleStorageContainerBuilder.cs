using System.Reflection;
using Autofac;
using OpenRailData.ScheduleStorage.EntityFramework.UnitOfWork;
using OpenRailData.ScheduleStorage.RecordStorageProcessor;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public static class EntityFrameworkScheduleStorageContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var scheduleStorage = typeof(AssociationAmendScheduleRecordStorageProcessor).GetTypeInfo().Assembly;

            builder.RegisterType<ScheduleRecordStorageService>().As<IScheduleRecordStorageService>();

            builder.RegisterAssemblyTypes(scheduleStorage)
                .Where(t => t.Name.EndsWith("StorageProcessor"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(scheduleStorage)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            
            builder.RegisterType<ScheduleUnitOfWorkFactory>().As<IScheduleUnitOfWorkFactory>();
            builder.RegisterType<ScheduleUnitOfWork>().As<IScheduleUnitOfWork>();

            builder.RegisterType<SqlServerScheduleContextFactory>().As<IScheduleContextFactory>();
            builder.RegisterType<ScheduleContext>().As<IScheduleContext>();

            builder.RegisterType<StaticScheduleContextConfigurationProvider>()
                .As<IScheduleContextConfigurationProvider>();

            builder.RegisterType<ScheduleDatabaseMigrator>().As<IScheduleDatabaseMigrator>();
            
            return builder;
        }
    }
}