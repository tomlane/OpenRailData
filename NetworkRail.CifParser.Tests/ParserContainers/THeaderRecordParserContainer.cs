using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class THeaderRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var dateTimeParserMock = new Mock<IDateTimeParser>();
            var updateTypeParserMock = new Mock<IExtractUpdateTypeParser>();
            var timeParserMock = new Mock<ITimeParser>();

            Assert.Throws<ArgumentNullException>(() => new HeaderRecordParserContainer(null, updateTypeParserMock.Object, timeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new HeaderRecordParserContainer(dateTimeParserMock.Object, null, timeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new HeaderRecordParserContainer(dateTimeParserMock.Object, updateTypeParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var dateTimeParserMock = new Mock<IDateTimeParser>();
            var updateTypeParserMock = new Mock<IExtractUpdateTypeParser>();
            var timeParserMock = new Mock<ITimeParser>();

            var container = new HeaderRecordParserContainer(dateTimeParserMock.Object, updateTypeParserMock.Object, timeParserMock.Object);

            Assert.AreEqual(dateTimeParserMock.Object, container.DateTimeParser);
            Assert.AreEqual(updateTypeParserMock.Object, container.UpdateTypeParser);
            Assert.AreEqual(updateTypeParserMock.Object, container.TimeParser);
        }
    }
}