using System;
using System.Runtime.Remoting;
using Moq;
using NetworkRail.CifParser.RecordBuilders;
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
            var associationRecordBuilderMock = new Mock<ICifRecordBuilder<AssociationRecord>>();
            var basicScheduleExtraDetailsRecordBuilderMock = new Mock<ICifRecordBuilder<BasicScheduleExtraDetailsRecord>>();
            var basicScheduleRecordBuilderMock = new Mock<ICifRecordBuilder<BasicScheduleRecord>>();
            var changesEnRouteRecordBuilderMock = new Mock<ICifRecordBuilder<ChangesEnRouteRecord>>();
            var headerRecordBuilderMock = new Mock<ICifRecordBuilder<HeaderRecord>>();
            var locationRecordBuilderMock = new Mock<ICifRecordBuilder<LocationRecord>>();
            var tiplocDeleteRecordBuilderMock = new Mock<ICifRecordBuilder<TiplocDeleteRecord>>();
            var tiplocInsertAmendRecordBuilderMock = new Mock<ICifRecordBuilder<TiplocInsertAmendRecord>>();

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
            var associationRecordBuilderMock = new Mock<ICifRecordBuilder<AssociationRecord>>();
            var basicScheduleExtraDetailsRecordBuilderMock = new Mock<ICifRecordBuilder<BasicScheduleExtraDetailsRecord>>();
            var basicScheduleRecordBuilderMock = new Mock<ICifRecordBuilder<BasicScheduleRecord>>();
            var changesEnRouteRecordBuilderMock = new Mock<ICifRecordBuilder<ChangesEnRouteRecord>>();
            var headerRecordBuilderMock = new Mock<ICifRecordBuilder<HeaderRecord>>();
            var locationRecordBuilderMock = new Mock<ICifRecordBuilder<LocationRecord>>();
            var tiplocDeleteRecordBuilderMock = new Mock<ICifRecordBuilder<TiplocDeleteRecord>>();
            var tiplocInsertAmendRecordBuilderMock = new Mock<ICifRecordBuilder<TiplocInsertAmendRecord>>();

            var container = new CifRecordBuilderContainer(associationRecordBuilderMock.Object, basicScheduleExtraDetailsRecordBuilderMock.Object,
                basicScheduleRecordBuilderMock.Object, changesEnRouteRecordBuilderMock.Object,
                headerRecordBuilderMock.Object, locationRecordBuilderMock.Object, tiplocDeleteRecordBuilderMock.Object,
                tiplocInsertAmendRecordBuilderMock.Object);

            Assert.AreEqual(associationRecordBuilderMock.Object, container.AssociationRecordBuilder);
            Assert.AreEqual(basicScheduleExtraDetailsRecordBuilderMock.Object, container.BasicScheduleExtraDetailsRecordBuilder);
            Assert.AreEqual(basicScheduleRecordBuilderMock.Object, container.BasicScheduleRecordBuilder);
            Assert.AreEqual(changesEnRouteRecordBuilderMock.Object, container.ChangesEnRouteRecordBuilder);
            Assert.AreEqual(headerRecordBuilderMock.Object, container.HeaderRecordBuilder);
            Assert.AreEqual(locationRecordBuilderMock.Object, container.LocationRecordBuilder);
            Assert.AreEqual(tiplocDeleteRecordBuilderMock.Object, container.TiplocDeleteRecordBuilder);
            Assert.AreEqual(tiplocInsertAmendRecordBuilderMock.Object, container.TiplocInsertAmendRecordBuilder);
        }
    }
}