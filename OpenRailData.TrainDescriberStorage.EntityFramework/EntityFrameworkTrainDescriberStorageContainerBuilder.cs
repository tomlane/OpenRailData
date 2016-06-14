using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.TrainDescriberStorage.EntityFramework.Repository;
using OpenRailData.TrainDescriberStorage.EntityFramework.StorageProcessor;
using OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public static class EntityFrameworkTrainDescriberStorageContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<ITrainDescriberStorageService, TrainDescriberStorageService>();
            
            container.RegisterType<ITrainDescriberUnitOfWorkFactory, TrainDescriberUnitOfWorkFactory>();
            container.RegisterType<ITrainDescriberUnitOfWork, TrainDescriberUnitOfWork>();
            container.RegisterType<IDbContextFactory<TrainDescriberContext>, TrainDescriberContextFactory>();

            container.RegisterType<ITrainDescriberStorageProcessor, SignalMessageStorageProcessor>("SignalMessageStorageProcessor");
            container.RegisterType<ITrainDescriberStorageProcessor, BerthMessageStorageProcessor>("BerthMessageStorageProcessor");

            container.RegisterType<ITrainDescriberRepository<SignalMessage>, SignalMessageRepository>();
            container.RegisterType<ITrainDescriberRepository<BerthMessage>, BerthMessageRepository>();

            return container;
        }
    }
}