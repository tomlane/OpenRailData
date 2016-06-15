using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementStorage.EntityFramework.Repository;
using OpenRailData.TrainMovementStorage.EntityFramework.StorageProcessor;
using OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public static class EntityFrameworkTrainMovementStorageContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<ITrainMovementStorageService, TrainMovementStorageService>();

            container.RegisterType<ITrainMovementUnitOfWorkFactory, TrainMovementUnitOfWorkFactory>();
            container.RegisterType<ITrainMovementUnitOfWork, TrainMovementUnitOfWork>();
            container.RegisterType<IDbContextFactory<TrainMovementContext>, TrainMovementContextFactory>();

            container.RegisterType<ITrainMovementRepository<TrainActivation>, TrainActivationRepository>();
            container.RegisterType<ITrainMovementRepository<TrainCancellation>, TrainCancellationRepository>();
            container.RegisterType<ITrainMovementRepository<TrainMovement>, TrainMovementRepository>();
            container.RegisterType<ITrainMovementRepository<TrainReinstatement>, TrainReinstatementRepository>();
            container.RegisterType<ITrainMovementRepository<ChangeOfOrigin>, ChangeOfOriginRepository>();
            container.RegisterType<ITrainMovementRepository<ChangeOfIdentity>, ChangeOfIdentityRepository>();

            container.RegisterType<ITrainMovementStorageProcessor, TrainActivationStorageProcessor>("TrainActivationStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainCancellationStorageProcessor>("TrainCancellationStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainMovementStorageProcessor>("TrainMovementStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainReinstatmentStorageProcessor>("TrainReinstatementStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfOriginStorageProcessor>("ChangeOfOriginStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfIdentityStorageProcessor>("ChangeOfIdentityStorageProcessor");

            return container;
        }
    }
}