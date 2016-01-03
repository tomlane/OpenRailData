using System;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TAssociationRecordBuilder
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordBuilder = new AssociationRecordBuilder();

                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordBuilder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_revise_record()
            {
                var recordBuilder = new AssociationRecordBuilder();

                string recordToParse = "AARW01400W005701512131602070000001   ORPNGTN  T                                C";

                var result = recordBuilder.BuildRecord(recordToParse);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = "R",
                    MainTrainUid = "W01400",
                    AssocTrainUid = "W00570",
                    DateFrom = "151213",
                    DateTo = "160207",
                    AssocDays = Days.Sunday,
                    Category = string.Empty,
                    DateIndicator = string.Empty,
                    Location = "ORPNGTN",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = string.Empty,
                    StpIndicator = "C"
                };

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
                var recordBuilder = new AssociationRecordBuilder();

                string record = "AANL82468L839221512191601020000010   CLCHSTR  T                                C";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = "N",
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = "151219",
                    DateTo = "160102",
                    AssocDays = Days.Saturday,
                    Category = string.Empty,
                    DateIndicator = string.Empty,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = string.Empty,
                    StpIndicator = "C"
                };

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
                var recordBuilder = new AssociationRecordBuilder();

                string record = "AADL82468L83922151226                CLCHSTR  T                                C";

                var result = recordBuilder.BuildRecord(record);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = "D",
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = "151226",
                    DateTo = string.Empty,
                    Category = string.Empty,
                    DateIndicator = string.Empty,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = string.Empty,
                    StpIndicator = "C"
                };

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