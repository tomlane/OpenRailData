using Microsoft.Practices.Unity;
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

            container.RegisterType<IScheduleReader, FileScheduleReader>();
            container.RegisterType<IScheduleParser, CifScheduleParser>();

            container.RegisterType<ICifRecordParser, AssociationRecordParser>("AssociationRecordParser");
            container.RegisterType<ICifRecordParser, BasicScheduleExtraDetailsRecordParser>("BasicScheduleExtraDetailsRecordParser");
            container.RegisterType<ICifRecordParser, BasicScheduleRecordParser>("BasicScheduleRecordParser");
            container.RegisterType<ICifRecordParser, ChangesEnRouteRecordParser>("ChangesEnRouteRecordParser");
            container.RegisterType<ICifRecordParser, HeaderRecordParser>("HeaderRecordParser");
            container.RegisterType<ICifRecordParser, OriginLocationRecordParser>("OriginLocationRecordParser");
            container.RegisterType<ICifRecordParser, IntermediateLocationRecordParser>("IntermediateLocationRecordParser");
            container.RegisterType<ICifRecordParser, TerminatingLocationRecordParser>("TerminatingLocationRecordParser");
            container.RegisterType<ICifRecordParser, TiplocDeleteRecordParser>("TiplocDeleteRecordParser");
            container.RegisterType<ICifRecordParser, TiplocInsertRecordParser>("TiplocInsertRecordParser");
            container.RegisterType<ICifRecordParser, TiplocAmendRecordParser>("TiplocAmendRecordParser");
            container.RegisterType<ICifRecordParser, EndOfFileRecordParser>("EndOfFileRecordParser");
            
            container.RegisterType<IRecordEnumPropertyParser, AssociationCategoryParser>("AssociationCategoryParser");
            container.RegisterType<IRecordEnumPropertyParser, AssociationTypeParser>("AssociationTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, BankHolidayRunningParser>("BankHolidayRunningParser");
            container.RegisterType<IRecordEnumPropertyParser, CateringCodeParser>("CateringCodeParser");
            container.RegisterType<IRecordEnumPropertyParser, DateIndicatorParser>("DateIndicatorParser");
            container.RegisterType<IRecordEnumPropertyParser, ExtractUpdateTypeParser>("ExtractUpdateTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, LocationActivityParser>("LocationActivityParser");
            container.RegisterType<IRecordEnumPropertyParser, OperatingCharacteristicsParser>("OperatingCharacteristicsParser");
            container.RegisterType<IRecordEnumPropertyParser, ReservationDetailsParser>("ReservationDetailsParser");
            container.RegisterType<IRecordEnumPropertyParser, RunningDaysParser>("RunningDaysParser");
            container.RegisterType<IRecordEnumPropertyParser, SeatingClassParser>("SeatingClassParser");
            container.RegisterType<IRecordEnumPropertyParser, ServiceBrandingParser>("ServiceBrandingParser");
            container.RegisterType<IRecordEnumPropertyParser, SleeperDetailsParser>("SleeperDetailsParser");
            container.RegisterType<IRecordEnumPropertyParser, StpIndicatorParser>("StpIndicatorParser");
            container.RegisterType<IRecordEnumPropertyParser, TransactionTypeParser>("TransactionTypeParser");

            container.RegisterType<ITimingAllowanceParser, TimingAllowanceParser>();
            container.RegisterType<IDateTimeParser, DateTimeParser>();
            
            return container;
        }
    }
}