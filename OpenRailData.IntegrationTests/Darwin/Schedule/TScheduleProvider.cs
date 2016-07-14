using Autofac;
using OpenRailData.Darwin;
using Xunit;

namespace OpenRailData.IntegrationTests.Darwin.Schedule
{
    public class TScheduleProvider
    {
        private IContainer _container;

        public TScheduleProvider()
        {
            var builder = DarwinModuleContainerBuilder.Build();

            _container = builder.Build();
        }

        [Fact]
        public void can_be_built_from_static_container()
        {
            var provider = _container.Resolve<IDarwinScheduleProvider>();

            Assert.IsType<DarwinScheduleProvider>(provider);
        }
    }
}