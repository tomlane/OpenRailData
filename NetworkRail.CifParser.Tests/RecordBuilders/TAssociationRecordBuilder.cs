using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TAssociationRecordBuilder
    {
        private static IUnityContainer _container;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var associationRecordParserContainer = new Mock<IAssociationRecordParserContainer>();

            Assert.Throws<ArgumentNullException>(() => new AssociationRecordBuilder(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var associationRecordParserContainer = new Mock<IAssociationRecordParserContainer>();

                var recordBuilder = new AssociationRecordBuilder(associationRecordParserContainer.Object);

                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_revise_record()
            {
                var associationRecordParserContainer = _container.Resolve<IAssociationRecordParserContainer>();

                var recordBuilder = new AssociationRecordBuilder(associationRecordParserContainer);

                string recordToParse = "AARW01400W005701512131602070000001   ORPNGTN  T                                C";

                var result = recordBuilder.BuildRecord(recordToParse);

                var expectedResult = new AssociationRecord
                {
                    RecordIdentity = CifRecordType.Association,
                    TransactionType = TransactionType.Revise,
                    MainTrainUid = "W01400",
                    AssocTrainUid = "W00570",
                    DateFrom = new DateTime(2015, 12, 13),
                    DateTo = new DateTime(2016, 2, 7),
                    AssocDays = Days.Sunday,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "ORPNGTN",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TransactionType, result.TransactionType);
                Assert.AreEqual(expectedResult.MainTrainUid, result.MainTrainUid);
                Assert.AreEqual(expectedResult.AssocTrainUid, result.AssocTrainUid);
                Assert.AreEqual(expectedResult.DateFrom, result.DateFrom);
                Assert.AreEqual(expectedResult.DateTo, result.DateTo);
                Assert.AreEqual(expectedResult.AssocDays, result.AssocDays);
                Assert.AreEqual(expectedResult.Category, result.Category);
                Assert.AreEqual(expectedResult.DateIndicator, result.DateIndicator);
                Assert.AreEqual(expectedResult.Location, result.Location);
                Assert.AreEqual(expectedResult.BaseLocationSuffix, result.BaseLocationSuffix);
                Assert.AreEqual(expectedResult.AssocLocationSuffix, result.AssocLocationSuffix);
                Assert.AreEqual(expectedResult.DiagramType, result.DiagramType);
                Assert.AreEqual(expectedResult.AssocType, result.AssocType);
                Assert.AreEqual(expectedResult.StpIndicator, result.StpIndicator);
            }

            [Test]
            public void returns_expected_result_with_new_record()
            {
                var associationRecordParserContainer = _container.Resolve<IAssociationRecordParserContainer>();

                var recordBuilder = new AssociationRecordBuilder(associationRecordParserContainer);

                string record = "AANL82468L839221512191601020000010   CLCHSTR  T                                C";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new AssociationRecord
                {
                    RecordIdentity = CifRecordType.Association,
                    TransactionType = TransactionType.New,
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = new DateTime(2015, 12, 19),
                    DateTo = new DateTime(2016, 1, 2),
                    AssocDays = Days.Saturday,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TransactionType, result.TransactionType);
                Assert.AreEqual(expectedResult.MainTrainUid, result.MainTrainUid);
                Assert.AreEqual(expectedResult.AssocTrainUid, result.AssocTrainUid);
                Assert.AreEqual(expectedResult.DateFrom, result.DateFrom);
                Assert.AreEqual(expectedResult.DateTo, result.DateTo);
                Assert.AreEqual(expectedResult.AssocDays, result.AssocDays);
                Assert.AreEqual(expectedResult.Category, result.Category);
                Assert.AreEqual(expectedResult.DateIndicator, result.DateIndicator);
                Assert.AreEqual(expectedResult.Location, result.Location);
                Assert.AreEqual(expectedResult.BaseLocationSuffix, result.BaseLocationSuffix);
                Assert.AreEqual(expectedResult.AssocLocationSuffix, result.AssocLocationSuffix);
                Assert.AreEqual(expectedResult.DiagramType, result.DiagramType);
                Assert.AreEqual(expectedResult.AssocType, result.AssocType);
                Assert.AreEqual(expectedResult.StpIndicator, result.StpIndicator);
            }

            [Test]
            public void returns_expected_result_with_delete_record()
            {
                var associationRecordParserContainer = _container.Resolve<IAssociationRecordParserContainer>();

                var recordBuilder = new AssociationRecordBuilder(associationRecordParserContainer);

                string record = "AADL82468L83922151226                CLCHSTR  T                                C";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new AssociationRecord
                {
                    RecordIdentity = CifRecordType.Association,
                    TransactionType = TransactionType.Delete,
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = new DateTime(2015, 12, 26),
                    DateTo = null,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TransactionType, result.TransactionType);
                Assert.AreEqual(expectedResult.MainTrainUid, result.MainTrainUid);
                Assert.AreEqual(expectedResult.AssocTrainUid, result.AssocTrainUid);
                Assert.AreEqual(expectedResult.DateFrom, result.DateFrom);
                Assert.AreEqual(expectedResult.DateTo, result.DateTo);
                Assert.AreEqual(expectedResult.AssocDays, result.AssocDays);
                Assert.AreEqual(expectedResult.Category, result.Category);
                Assert.AreEqual(expectedResult.DateIndicator, result.DateIndicator);
                Assert.AreEqual(expectedResult.Location, result.Location);
                Assert.AreEqual(expectedResult.BaseLocationSuffix, result.BaseLocationSuffix);
                Assert.AreEqual(expectedResult.AssocLocationSuffix, result.AssocLocationSuffix);
                Assert.AreEqual(expectedResult.DiagramType, result.DiagramType);
                Assert.AreEqual(expectedResult.AssocType, result.AssocType);
                Assert.AreEqual(expectedResult.StpIndicator, result.StpIndicator);
            }
        }
    }
}