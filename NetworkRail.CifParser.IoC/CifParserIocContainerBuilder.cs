using Microsoft.Practices.Unity;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.IoC
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleManager, CifScheduleManager>();

            container.RegisterType<ICifRecordParser, AssociationRecordParser>();
            container.RegisterType<ICifRecordParser, BasicScheduleExtraDetailsRecordParser>();
            container.RegisterType<ICifRecordParser, BasicScheduleRecordParser>();
            container.RegisterType<ICifRecordParser, ChangesEnRouteRecordParser>();
            container.RegisterType<ICifRecordParser, HeaderRecordParser>();
            container.RegisterType<ICifRecordParser, OriginLocationRecordParser>();
            container.RegisterType<ICifRecordParser, TiplocDeleteRecordParser>();
            container.RegisterType<ICifRecordParser, TiplocInsertRecordParser>();

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