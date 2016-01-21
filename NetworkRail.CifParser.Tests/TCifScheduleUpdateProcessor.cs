using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TCifScheduleUpdateProcessor
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var cifRecordParserMock = new Mock<ICifRecordParser>();

            Assert.Throws<ArgumentNullException>(() => new CifScheduleManager(null));
        }

        [Test]
        public void can_be_resolved_by_di()
        {
            var container = CifParserIocContainerBuilder.Build();

            var processor = container.Resolve<IScheduleManager>();

            Assert.IsInstanceOf<CifScheduleManager>(processor);
        }

        [TestFixture]
        class ProcessScheduleUpdate
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var cifRecordParserMock = new Mock<ICifRecordParser>();

                var updateProcessor = new CifScheduleManager(cifRecordParserMock.Object);

                Assert.Throws<ArgumentNullException>(() => updateProcessor.ParseScheduleEntites(null));
            }
        }
    }
}