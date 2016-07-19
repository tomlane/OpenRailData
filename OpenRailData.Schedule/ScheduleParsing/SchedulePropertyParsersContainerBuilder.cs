using System.Reflection;
using Autofac;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public static class SchedulePropertyParsersContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var scheduleParsing = typeof(AssociationCategoryParser).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(scheduleParsing)
                .Where(t => t.Name.EndsWith("Parser"))
                .AsImplementedInterfaces();

            return builder;
        }
    }
}