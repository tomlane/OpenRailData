using System.Reflection;
using Autofac;

namespace OpenRailData.MessageProcessing
{
    public static class MessageProcessingContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var messageProcessing = typeof(TrainMovementProcessingService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(messageProcessing)
                .Where(t => t.Name.EndsWith("MessageProcessor"))
                .AsImplementedInterfaces();

            return builder;
        }
    }
}