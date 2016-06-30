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

            builder.RegisterType<IScheduleRecordStorageService>().As<ScheduleRecordStorageService>();

            builder.RegisterAssemblyTypes(scheduleStorage)
                .Where(t => t.Name.EndsWith("StorageProcessor"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(scheduleStorage)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            
            builder.RegisterType<ScheduleUnitOfWorkFactory>().As<IScheduleUnitOfWorkFactory>();
            builder.RegisterType<ScheduleUnitOfWork>().As<IScheduleUnitOfWork>();

            builder.RegisterType<ScheduleContext>().As<IScheduleContext>();
            
            return builder;
        }
    }
}