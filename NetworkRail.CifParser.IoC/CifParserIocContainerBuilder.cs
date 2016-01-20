﻿using Microsoft.Practices.Unity;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.IoC
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleUpdateProcessor, CifScheduleUpdateProcessor>();

            container.RegisterType<ICifRecordParser, CifRecordParser>();

            container.RegisterType<ICifRecordBuilderContainer, CifRecordBuilderContainer>();

            container.RegisterType<ICifRecordBuilder<AssociationRecord>, AssociationRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<BasicScheduleExtraDetailsRecord>, BasicScheduleExtraDetailsRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<BasicScheduleRecord>, BasicScheduleRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<ChangesEnRouteRecord>, ChangesEnRouteRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<HeaderRecord>, HeaderRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<LocationRecord>, LocationRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<TiplocDeleteRecord>, TiplocDeleteRecordBuilder>();
            container.RegisterType<ICifRecordBuilder<TiplocInsertAmendRecord>, TiplocInsertAmendRecordBuilder>();

            container.RegisterType<IAssociationRecordParserContainer, AssociationRecordParserContainer>();
            container.RegisterType<IBasicScheduleRecordParserContainer, BasicScheduleRecordParserContainer>();
            container.RegisterType<IChangesEnRouteRecordParserContainer, ChangesEnRouteRecordParserContainer>();
            container.RegisterType<IHeaderRecordParserContainer, HeaderRecordParserContainer>();
            container.RegisterType<ILocationRecordParserContainer, LocationRecordParserContainer>();

            container.RegisterType<IAssociationCategoryParser, AssociationCategoryParser>();
            container.RegisterType<IAssociationTypeParser, AssociationTypeParser>();
            container.RegisterType<IBankHolidayRunningParser, BankHolidayRunningParser>();
            container.RegisterType<IDateIndicatorParser, DateIndicatorParser>();
            container.RegisterType<IDateTimeParser, DateTimeParser>();
            container.RegisterType<IExtractUpdateTypeParser, ExtractUpdateTypeParser>();
            container.RegisterType<ILocationActivityParser, LocationActivityParser>();
            container.RegisterType<ILocationTypeParser, LocationTypeParser>();
            container.RegisterType<IOperatingCharacteristicsParser, OperatingCharacteristicsParser>();
            container.RegisterType<IReservationDetailsParser, ReservationsDetailsParser>();
            container.RegisterType<IRunningDaysParser, RunningDaysParser>();
            container.RegisterType<ISeatingClassParser, SeatingClassParser>();
            container.RegisterType<ISleeperDetailsParser, SleeperDetailsParser>();
            container.RegisterType<IStpIndicatorParser, StpIndicatorParser>();
            container.RegisterType<ITimeParser, TimeParser>();
            container.RegisterType<ITransactionTypeParser, TransactionTypeParser>();

            return container;
        }
    }
}