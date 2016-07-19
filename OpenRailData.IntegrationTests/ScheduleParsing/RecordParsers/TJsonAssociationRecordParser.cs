using System;
using Autofac;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class TJsonAssociationRecordParser
    {
        private static IContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TJsonAssociationRecordParser()
        {
            var builder = SchedulePropertyParsersContainerBuilder.Build();
            builder = CifScheduleParsingContainerBuilder.Build(builder);

            _container = builder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private JsonAssociationRecordParser BuildParser()
        {
            return new JsonAssociationRecordParser(_enumPropertyParsers);
        }

        [Fact]
        public void association_parser_parses_create_association_message_correctly()
        {
            var message = "{\"JsonAssociationV1\":{\"transaction_type\":\"Create\",\"main_train_uid\":\"C40300\",\"assoc_train_uid\":\"C40607\",\"assoc_start_date\":\"2016-05-15T00:00:00Z\",\"assoc_end_date\":\"2016-12-04T00:00:00Z\",\"assoc_days\":\"0000001\",\"category\":\"NP\",\"date_indicator\":\"S\",\"location\":\"BRNSTPL\",\"base_location_suffix\":null,\"assoc_location_suffix\":null,\"diagram_type\":\"T\",\"CIF_stp_indicator\":\"P\"}}";

            var parser = BuildParser();

            var assocation = new AssociationRecord
            {
                AssocDays = Days.Sunday,
                AssocLocationSuffix = string.Empty,
                AssocTrainUid = "C40607",
                BaseLocationSuffix = string.Empty,
                Category = AssociationCategory.NP,
                StartDate = new DateTime(2016, 5, 15),
                DateIndicator = DateIndicator.S,
                EndDate = new DateTime(2016, 12, 4),
                DiagramType = "T",
                Location = "BRNSTPL",
                MainTrainUid = "C40300",
                RecordIdentity = ScheduleRecordType.AAN,
                StpIndicator = StpIndicator.P,
                AssocType = AssociationType.None,
                UniqueId = "C40300C4060720160515TBRNSTPLP"
            };

            var result = parser.ParseRecord(message);

            Assert.Equal(assocation, result);
        }

        [Fact]
        public void association_parser_parses_delete_association_message_correctly()
        {
            var message = "{\"JsonAssociationV1\":{\"transaction_type\":\"Delete\",\"main_train_uid\":\"L27500\",\"assoc_train_uid\":\"L29154\",\"assoc_start_date\":\"2016-06-06T00:00:00Z\",\"location\":\"CLCHSTR\",\"base_location_suffix\":null,\"diagram_type\":\"T\",\"CIF_stp_indicator\":\"C\"}}";

            var parser = BuildParser();

            var association = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAD,
                MainTrainUid = "L27500",
                AssocTrainUid = "L29154",
                StartDate = new DateTime(2016, 6, 6),
                Location = "CLCHSTR",
                BaseLocationSuffix = string.Empty,
                DiagramType = "T",
                StpIndicator = StpIndicator.C,
                UniqueId = "L27500L2915420160606TCLCHSTRC"
            };

            var result = parser.ParseRecord(message);

            Assert.Equal(association, result);
        }
    }
}