using Autofac;

namespace OpenRailData.BootstrapperJobs
{
    public static class BootstrapperJobsContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            builder.RegisterType<NetworkRailScheduleScheduleBootstrapperJob>()
                .As<INetworkRailScheduleDataBootstrapperJob>();

            builder.RegisterType<DarwinLocationDataBootstrapperJob>().As<IDarwinLocationDataBootstrapperJob>();

            return builder;
        }
    }
}