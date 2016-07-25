using System.Reflection;
using Autofac;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public static class ScheduleModuleContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var scheduleParsing = typeof(AssociationCategoryParser).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(scheduleParsing)
                .Where(t => t.Name.EndsWith("Parser"))
                .AsImplementedInterfaces();

            builder.RegisterType<TiplocEditor>().As<ITiplocEditor>();

            builder.RegisterType<ScheduleProvider>().As<IScheduleProvider>();
            builder.RegisterType<TiplocProvider>().As<ITiplocProvider>();
            builder.RegisterType<AssociationProvider>().As<IAssociationProvider>();

            return builder;
        }
    }
}