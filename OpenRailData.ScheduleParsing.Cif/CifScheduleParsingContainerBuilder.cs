using System.Reflection;
using Autofac;

namespace OpenRailData.ScheduleParsing.Cif
{
    public static class CifScheduleParsingContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var scheduleParsing = typeof(CifScheduleRecordParsingService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(scheduleParsing)
                .Where(t => t.Name.EndsWith("RecordParser"))
                .AsImplementedInterfaces();

            builder.RegisterType<CifScheduleRecordParsingService>().As<IScheduleRecordParsingService>();

            return builder;
        }
    }
}