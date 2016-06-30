using System.Reflection;
using Autofac;
using OpenRailData.TrainDescriberStorage.EntityFramework.Repository;
using OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public static class EntityFrameworkTrainDescriberStorageContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var describerStorage = typeof(SignalMessageRepository).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(describerStorage)
                .Where(t => t.Name.EndsWith("StorageProcessor"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(describerStorage)
                .Where(t => t.Name.EndsWith("MessageRepository"))
                .AsImplementedInterfaces();

            builder.RegisterType<TrainDescriberStorageService>().As<ITrainDescriberStorageService>();

            builder.RegisterType<TrainDescriberUnitOfWorkFactory>().As<ITrainDescriberUnitOfWorkFactory>();
            builder.RegisterType<TrainDescriberUnitOfWork>().As<ITrainDescriberUnitOfWork>();
            builder.RegisterType<TrainDescriberContextFactory>().As<ITrainDescriberContextFactory>();
            
            return builder;
        }
    }
}