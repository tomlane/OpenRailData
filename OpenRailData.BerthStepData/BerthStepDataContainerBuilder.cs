using Microsoft.Practices.Unity;

namespace OpenRailData.BerthStepData
{
    public static class BerthStepDataContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IBerthStepDataProvider, BerthStepDataProvider>();

            return container;
        }
    }
}