using Autofac;
using OpenRailData.Darwin.ScheduleParsing;

namespace OpenRailData.Darwin
{
    public static class DarwinModuleContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null) 
                builder = new ContainerBuilder();

            builder.RegisterType<XmlDarwinScheduleParser>().As<IDarwinScheduleParser>();

            return builder;
        }
    }
}