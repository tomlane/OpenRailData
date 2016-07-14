using Autofac;
using OpenRailData.Darwin.DataDecompression;
using OpenRailData.Darwin.DataFetching;
using OpenRailData.Darwin.ReferenceData;
using OpenRailData.Darwin.ScheduleParsing;

namespace OpenRailData.Darwin
{
    public static class DarwinModuleContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null) 
                builder = new ContainerBuilder();

            builder.RegisterType<LocalDarwinDataFileFetcher>().As<IDarwinDataFileFetcher>();

            builder.RegisterType<GzipDataDecompressor>().As<IDataDecompressor>();

            builder.RegisterType<XmlDarwinScheduleParser>().As<IDarwinScheduleParser>();

            builder.RegisterType<DarwinScheduleProvider>().As<IDarwinScheduleProvider>();

            builder.RegisterType<DarwinReferenceDataProvider>().As<IDarwinReferenceDataProvider>();

            builder.RegisterType<XmlDarwinReferenceDataParser>().As<IDarwinReferenceDataParser>();
            
            return builder;
        }
    }
}