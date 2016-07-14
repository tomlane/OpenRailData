using Autofac;
using OpenRailData.Darwin;
using Xunit;

namespace OpenRailData.IntegrationTests.Darwin.ReferenceData
{
    public class TReferenceDataProvider
    {
        private readonly IContainer _container;

        public TReferenceDataProvider()
        {
            var builder = DarwinModuleContainerBuilder.Build();

            _container = builder.Build();
        }

        [Fact]
        public void can_be_built_from_static_container()
        {
            var provider = _container.Resolve<IDarwinReferenceDataProvider>();

            Assert.IsType<DarwinReferenceDataProvider>(provider);
        }
    }
}