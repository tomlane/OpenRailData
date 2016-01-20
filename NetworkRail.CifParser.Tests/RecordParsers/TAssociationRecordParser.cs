using System;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TAssociationRecordParser
    {
        private static IUnityContainer _container;
        private static IAssociationRecordParserContainer _parserContainer;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _parserContainer = _container.Resolve<IAssociationRecordParserContainer>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParser(null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordBuilder = new AssociationRecordParser(_parserContainer);

                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_revise_record()
            {
                var recordBuilder = new AssociationRecordParser(_parserContainer);

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

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_with_new_record()
            {
                var recordBuilder = new AssociationRecordParser(_parserContainer);

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

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_with_delete_record()
            {
                var recordBuilder = new AssociationRecordParser(_parserContainer);

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

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}