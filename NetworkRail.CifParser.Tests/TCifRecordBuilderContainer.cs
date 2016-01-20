using System;
using Moq;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TCifRecordBuilderContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var associationRecordBuilderMock = new Mock<ICifRecordParser<AssociationRecord>>();
            var basicScheduleExtraDetailsRecordBuilderMock = new Mock<ICifRecordParser<BasicScheduleExtraDetailsRecord>>();
            var basicScheduleRecordBuilderMock = new Mock<ICifRecordParser<BasicScheduleRecord>>();
            var changesEnRouteRecordBuilderMock = new Mock<ICifRecordParser<ChangesEnRouteRecord>>();
            var headerRecordBuilderMock = new Mock<ICifRecordParser<HeaderRecord>>();
            var locationRecordBuilderMock = new Mock<ICifRecordParser<LocationRecord>>();
            var tiplocDeleteRecordBuilderMock = new Mock<ICifRecordParser<TiplocDeleteRecord>>();
            var tiplocInsertAmendRecordBuilderMock = new Mock<ICifRecordParser<TiplocInsertAmendRecord>>();

            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(null, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, null, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, null, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, null, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, null, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, null, tiplocDeleteRecordBuilderMock.Object, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, null, tiplocInsertAmendRecordBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object, basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object, headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object, null));
        }

        [Test]
        public void constructs_expected_container()
        {
            var associationRecordBuilderMock = new Mock<ICifRecordParser<AssociationRecord>>();
            var basicScheduleExtraDetailsRecordBuilderMock = new Mock<ICifRecordParser<BasicScheduleExtraDetailsRecord>>();
            var basicScheduleRecordBuilderMock = new Mock<ICifRecordParser<BasicScheduleRecord>>();
            var changesEnRouteRecordBuilderMock = new Mock<ICifRecordParser<ChangesEnRouteRecord>>();
            var headerRecordBuilderMock = new Mock<ICifRecordParser<HeaderRecord>>();
            var locationRecordBuilderMock = new Mock<ICifRecordParser<LocationRecord>>();
            var tiplocDeleteRecordBuilderMock = new Mock<ICifRecordParser<TiplocDeleteRecord>>();
            var tiplocInsertAmendRecordBuilderMock = new Mock<ICifRecordParser<TiplocInsertAmendRecord>>();

            var container = new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object,
                basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object,
                headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object,
                tiplocInsertAmendRecordBuilderMock.Object);

            Assert.AreEqual(associationRecordBuilderMock.Object, container.AssociationRecordParser);
            Assert.AreEqual(basicScheduleExtraDetailsRecordBuilderMock.Object, container.BasicScheduleExtraDetailsRecordParser);
            Assert.AreEqual(basicScheduleRecordBuilderMock.Object, container.BasicScheduleRecordParser);
            Assert.AreEqual(changesEnRouteRecordBuilderMock.Object, container.ChangesEnRouteRecordParser);
            Assert.AreEqual(headerRecordBuilderMock.Object, container.HeaderRecordParser);
            Assert.AreEqual(locationRecordBuilderMock.Object, container.LocationRecordParser);
            Assert.AreEqual(tiplocDeleteRecordBuilderMock.Object, container.TiplocDeleteRecordParser);
            Assert.AreEqual(tiplocInsertAmendRecordBuilderMock.Object, container.TiplocInsertAmendRecordParser);
        }
    }
}