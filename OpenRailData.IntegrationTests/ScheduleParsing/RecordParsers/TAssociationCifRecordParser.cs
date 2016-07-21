using System;
using Autofac;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TAssociationCifRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        public TAssociationCifRecordParser()
        {
            var builder = ScheduleModuleContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _container = builder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        private static AssociationCifRecordParser BuildParser()
        {
            return new AssociationCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Fact]
        public void returns_expected_result_with_revise_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AARW01400W005701512131602070000001   ORPNGTN  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAR,
                MainTrainUid = "W01400",
                AssocTrainUid = "W00570",
                StartDate = new DateTime(2015, 12, 13),
                EndDate = new DateTime(2016, 2, 7),
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

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_expected_result_with_new_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AANL82468L839221512191601020000010   CLCHSTR  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAN,
                MainTrainUid = "L82468",
                AssocTrainUid = "L83922",
                StartDate = new DateTime(2015, 12, 19),
                EndDate = new DateTime(2016, 1, 2),
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

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_expected_result_with_delete_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AADL82468L83922151226                CLCHSTR  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAD,
                MainTrainUid = "L82468",
                AssocTrainUid = "L83922",
                StartDate = new DateTime(2015, 12, 26),
                EndDate = null,
                Category = AssociationCategory.None,
                DateIndicator = DateIndicator.None,
                Location = "CLCHSTR",
                BaseLocationSuffix = string.Empty,
                AssocLocationSuffix = string.Empty,
                DiagramType = "T",
                AssocType = AssociationType.None,
                StpIndicator = StpIndicator.C
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }
    }
}