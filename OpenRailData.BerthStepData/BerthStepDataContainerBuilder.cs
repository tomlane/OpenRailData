using Autofac;

namespace OpenRailData.BerthStepData
{
    public static class BerthStepDataContainerBuilder
    {
        public static ContainerBuilder Build(ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            builder.RegisterType<BerthStepDataProvider>().As<IBerthStepDataProvider>();

            return builder;
        }
    }
}