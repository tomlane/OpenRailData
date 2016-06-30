using System.Reflection;
using Autofac;

namespace OpenRailData.TrainDescriberParsing.Json
{
    public static class TrainDescriberParsingContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var describerParsing = typeof(TrainDescriberMessageParsingService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(describerParsing)
                .Where(t => t.Name.EndsWith("MessageParser"))
                .AsImplementedInterfaces();

            builder.RegisterType<ITrainDescriberMessageParsingService>().As<TrainDescriberMessageParsingService>();
            
            return builder;
        }
    }
}