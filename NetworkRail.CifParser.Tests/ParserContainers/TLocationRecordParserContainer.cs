using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class TLocationRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var locationTypeParserMock = new Mock<ILocationTypeParser>();
            var locationTimeParserMock = new Mock<ILocationTimeParser>();
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();
            var locationActivityParserMock = new Mock<ILocationActivityParser>();

            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(null, locationTimeParserMock.Object, timingAllowanceParserMock.Object, locationActivityParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(locationTypeParserMock.Object, null, timingAllowanceParserMock.Object, locationActivityParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(locationTypeParserMock.Object, locationTimeParserMock.Object, null, locationActivityParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(locationTypeParserMock.Object, locationTimeParserMock.Object, timingAllowanceParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var locationTypeParserMock = new Mock<ILocationTypeParser>();
            var locationTimeParserMock = new Mock<ILocationTimeParser>();
            var timingAllowanceParserMock = new Mock<ITimingAllowanceParser>();
            var locationActivityParserMock = new Mock<ILocationActivityParser>();

            var container = new LocationRecordParserContainer(locationTypeParserMock.Object, locationTimeParserMock.Object, timingAllowanceParserMock.Object, locationActivityParserMock.Object);

            Assert.AreEqual(locationTypeParserMock.Object, container.LocationTypeParser);
            Assert.AreEqual(locationTimeParserMock.Object, container.LocationTimeParser);
            Assert.AreEqual(timingAllowanceParserMock.Object, container.TimingAllowanceParser);
            Assert.AreEqual(locationActivityParserMock.Object, container.LocationActivityParser);
        }
    }
}