using System.Reflection;
using Autofac;
using OpenRailData.TrainMovementStorage.EntityFramework.Repository;
using OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public static class EntityFrameworkTrainMovementStorageContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var movementStorage = typeof(ChangeOfIdentityRepository).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(movementStorage)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(movementStorage)
                .Where(t => t.Name.EndsWith("StorageProcessor"))
                .AsImplementedInterfaces();

            builder.RegisterType<TrainMovementStorageService>().As<ITrainMovementStorageService>();

            builder.RegisterType<TrainMovementUnitOfWorkFactory>().As<ITrainMovementUnitOfWorkFactory>();
            builder.RegisterType<TrainMovementUnitOfWork>().As<ITrainMovementUnitOfWork>();
            builder.RegisterType<SqlServerTrainMovementContextFactory>().As<ITrainMovementContextFactory>();
            
            return builder;
        }
    }
}