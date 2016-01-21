using Microsoft.Practices.Unity;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
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

            container.RegisterType<IScheduleManager, CifScheduleManager>();

            container.RegisterType<ICifRecordParser, CifRecordParser>();

            container.RegisterType<ICifRecordBuilderContainer, CifRecordBuilderContainer>();

            container.RegisterType<ICifRecordParser<AssociationRecord>, AssociationRecordParser>();
            container.RegisterType<ICifRecordParser<BasicScheduleExtraDetailsRecord>, BasicScheduleExtraDetailsRecordParser>();
            container.RegisterType<ICifRecordParser<BasicScheduleRecord>, BasicScheduleRecordParser>();
            container.RegisterType<ICifRecordParser<ChangesEnRouteRecord>, ChangesEnRouteRecordParser>();
            container.RegisterType<ICifRecordParser<HeaderRecord>, HeaderRecordParser>();
            container.RegisterType<ICifRecordParser<LocationRecord>, LocationRecordParser>();
            container.RegisterType<ICifRecordParser<TiplocDeleteRecord>, TiplocDeleteRecordParser>();
            container.RegisterType<ICifRecordParser<TiplocInsertAmendRecord>, TiplocInsertAmendRecordParser>();

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