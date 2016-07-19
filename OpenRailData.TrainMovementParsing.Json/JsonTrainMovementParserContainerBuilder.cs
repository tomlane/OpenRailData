using System.Reflection;
using Autofac;
using OpenRailData.TrainMovement.TrainMovementParsing;

namespace OpenRailData.TrainMovementParsing.Json
{
    public static class JsonTrainMovementParserContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var trainMovementParsing = typeof(TrainMovementParsingService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(trainMovementParsing)
                .Where(t => t.Name.EndsWith("MessageParser"))
                .AsImplementedInterfaces();

            builder.RegisterType<TrainMovementParsingService>().As<ITrainMovementParsingService>();
            
            return builder;
        }
    }
}