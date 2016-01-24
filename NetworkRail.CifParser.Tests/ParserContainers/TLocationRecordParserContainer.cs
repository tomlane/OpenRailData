using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordPropertyParsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class TLocationRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var timingAllowanceParserMock = new Mock<ITimeParser>();
            var locationActivityParserMock = new Mock<ILocationActivityParser>();

            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(null, locationActivityParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new LocationRecordParserContainer(timingAllowanceParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var timingAllowanceParserMock = new Mock<ITimeParser>();
            var locationActivityParserMock = new Mock<ILocationActivityParser>();

            var container = new LocationRecordParserContainer(timingAllowanceParserMock.Object, locationActivityParserMock.Object);

            Assert.AreEqual(timingAllowanceParserMock.Object, container.TimeParser);
            Assert.AreEqual(locationActivityParserMock.Object, container.LocationActivityParser);
        }
    }
}