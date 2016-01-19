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

            Assert.Throws<ArgumentNullException>(() => new CifScheduleUpdateProcessor(null));
        }

        [Test]
        public void can_be_resolved_by_di()
        {
            var container = CifParserIocContainerBuilder.Build();

            var processor = container.Resolve<IScheduleUpdateProcessor>();

            Assert.IsInstanceOf<CifScheduleUpdateProcessor>(processor);
        }

        [TestFixture]
        class ProcessScheduleUpdate
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var cifRecordParserMock = new Mock<ICifRecordParser>();

                var updateProcessor = new CifScheduleUpdateProcessor(cifRecordParserMock.Object);

                Assert.Throws<ArgumentNullException>(() => updateProcessor.ParseScheduleUpdate(null));
            }
        }
    }
}