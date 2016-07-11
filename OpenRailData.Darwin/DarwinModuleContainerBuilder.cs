using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Options;
using OpenRailData.Darwin.DataDecompression;
using OpenRailData.Darwin.ScheduleFetching;
using OpenRailData.Darwin.ScheduleParsing;

namespace OpenRailData.Darwin
{
    public static class DarwinModuleContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null) 
                builder = new ContainerBuilder();

            builder.RegisterType<LocalFileDarwinScheduleFetcher>().As<IDarwinScheduleFetcher>();

            builder.RegisterType<GzipDataDecompressor>().As<IDataDecompressor>();

            builder.RegisterType<XmlDarwinScheduleParser>().As<IDarwinScheduleParser>();

            builder.RegisterType<DarwinScheduleProvider>().As<IDarwinScheduleProvider>();

            builder.RegisterInstance<IOptions<DarwinLocalFileFetcherOptions>>(new OptionsManager<DarwinLocalFileFetcherOptions>(new List<IConfigureOptions<DarwinLocalFileFetcherOptions>>()));

            return builder;
        }
    }
}