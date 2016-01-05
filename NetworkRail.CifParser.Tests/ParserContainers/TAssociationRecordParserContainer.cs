using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class TAssociationRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var transactionTypeParserMock = new Mock<ITransactionTypeParser>();
            var dateTimeParserMock = new Mock<IDateTimeParser>();
            var runningDaysParserMock = new Mock<IRunningDaysParser>();
            var associationCategoryParserMock = new Mock<IAssociationCategoryParser>();
            var dateIndicatorParserMock = new Mock<IDateIndicatorParser>();
            var assocationTypeParserMock = new Mock<IAssociationTypeParser>();
            var stpIndicatorParserMock = new Mock<IStpIndicatorParser>();

            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(null, dateTimeParserMock.Object,runningDaysParserMock.Object, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, null, runningDaysParserMock.Object, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, null, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, runningDaysParserMock.Object, null, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, runningDaysParserMock.Object, associationCategoryParserMock.Object, null, assocationTypeParserMock.Object, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, runningDaysParserMock.Object, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, null, stpIndicatorParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, runningDaysParserMock.Object, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var transactionTypeParserMock = new Mock<ITransactionTypeParser>();
            var dateTimeParserMock = new Mock<IDateTimeParser>();
            var runningDaysParserMock = new Mock<IRunningDaysParser>();
            var associationCategoryParserMock = new Mock<IAssociationCategoryParser>();
            var dateIndicatorParserMock = new Mock<IDateIndicatorParser>();
            var assocationTypeParserMock = new Mock<IAssociationTypeParser>();
            var stpIndicatorParserMock = new Mock<IStpIndicatorParser>();

            var container = new AssociationRecordParserContainer(transactionTypeParserMock.Object, dateTimeParserMock.Object, runningDaysParserMock.Object, associationCategoryParserMock.Object, dateIndicatorParserMock.Object, assocationTypeParserMock.Object, stpIndicatorParserMock.Object);

            Assert.AreEqual(transactionTypeParserMock.Object, container.TransactionTypeParser);
            Assert.AreEqual(dateTimeParserMock.Object, container.DateTimeParser);
            Assert.AreEqual(runningDaysParserMock.Object, container.RunningDaysParser);
            Assert.AreEqual(associationCategoryParserMock.Object, container.AssociationCategoryParser);
            Assert.AreEqual(dateIndicatorParserMock.Object, container.DateIndicatorParser);
            Assert.AreEqual(assocationTypeParserMock.Object, container.AssociationTypeParser);
            Assert.AreEqual(stpIndicatorParserMock.Object, container.StpIndicatorParser);
        }
    }
}