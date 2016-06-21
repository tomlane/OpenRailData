using Microsoft.Practices.Unity;
using OpenRailData.MessageProcessing.ActivationProcessors;
using OpenRailData.MessageProcessing.CancellationProcessors;
using OpenRailData.MessageProcessing.ChangeOfIdentityProcessors;
using OpenRailData.MessageProcessing.ChangeOfOriginProcessors;
using OpenRailData.MessageProcessing.MovementProcessors;
using OpenRailData.MessageProcessing.ReinstatementProcessors;

namespace OpenRailData.MessageProcessing
{
    public static class MessageProcessingContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<ITrainMovementProcessingService, TrainMovementProcessingService>();

            container.RegisterType<ITrainMovementMessageProcessor, ActivationStorageProcessor>("ActivationStorageProcessor");

            container.RegisterType<ITrainMovementMessageProcessor, CancellationStorageProcessor>("CancellationStorageProcessor");

            container.RegisterType<ITrainMovementMessageProcessor, MovementStorageProcessor>("MovementStorageProcessor");

            container.RegisterType<ITrainMovementMessageProcessor, ReinstatementStorageProcessor>("ReinstatementStorageProcessor");

            container.RegisterType<ITrainMovementMessageProcessor, ChangeOfOriginStorageProcessor>("ChangeOfOriginStorageProcessor");

            container.RegisterType<ITrainMovementMessageProcessor, ChangeOfIdentityStorageProcessor>("ChangeOfIdentityStorageProcessor");

            return container;
        }
    }
}