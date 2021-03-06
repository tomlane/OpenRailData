﻿using System.Reflection;
using Autofac;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;

namespace OpenRailData.ScheduleParsing.Json
{
    public static class JsonScheduleParsingContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            var scheduleParsing = typeof(JsonScheduleRecordParsingService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(scheduleParsing)
                .Where(t => t.Name.EndsWith("RecordParser"))
                .AsImplementedInterfaces();

            builder.RegisterType<JsonScheduleRecordParsingService>().As<IScheduleRecordParsingService>();
            

            builder.RegisterType<TimingAllowanceParser>().As<ITimingAllowanceParser>();

            return builder;
        }
    }
}