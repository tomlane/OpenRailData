using Microsoft.Practices.Unity;
using NetworkRail.CifParser.CifRecordParsers;
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

            container.RegisterType<ICifRecordParser, AssociationCifRecordParser>("AssociationCifRecordParser");
            container.RegisterType<ICifRecordParser, BasicScheduleExtraDetailsCifRecordParser>("BasicScheduleExtraDetailsCifRecordParser");
            container.RegisterType<ICifRecordParser, BasicScheduleCifRecordParser>("BasicScheduleCifRecordParser");
            container.RegisterType<ICifRecordParser, ChangesEnRouteCifRecordParser>("ChangesEnRouteCifRecordParser");
            container.RegisterType<ICifRecordParser, HeaderCifRecordParser>("HeaderCifRecordParser");
            container.RegisterType<ICifRecordParser, OriginLocationCifRecordParser>("OriginLocationCifRecordParser");
            container.RegisterType<ICifRecordParser, IntermediateLocationCifRecordParser>("IntermediateLocationCifRecordParser");
            container.RegisterType<ICifRecordParser, TerminatingLocationCifRecordParser>("TerminatingLocationCifRecordParser");
            container.RegisterType<ICifRecordParser, TiplocDeleteCifRecordParser>("TiplocDeleteCifRecordParser");
            container.RegisterType<ICifRecordParser, TiplocInsertCifRecordParser>("TiplocInsertCifRecordParser");
            container.RegisterType<ICifRecordParser, TiplocAmendCifRecordParser>("TiplocAmendCifRecordParser");
            
            container.RegisterType<IRecordEnumPropertyParser, AssociationCategoryParser>("AssociationCategoryParser");
            container.RegisterType<IRecordEnumPropertyParser, AssociationTypeParser>("AssociationTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, BankHolidayRunningParser>("BankHolidayRunningParser");
            container.RegisterType<IRecordEnumPropertyParser, DateIndicatorParser>("DateIndicatorParser");
            container.RegisterType<IRecordEnumPropertyParser, ExtractUpdateTypeParser>("ExtractUpdateTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, LocationActivityParser>("LocationActivityParser");
            container.RegisterType<IRecordEnumPropertyParser, OperatingCharacteristicsParser>("OperatingCharacteristicsParser");
            container.RegisterType<IRecordEnumPropertyParser, PowerTypeParser>("PowerTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, ReservationDetailsParser>("ReservationDetailsParser");
            container.RegisterType<IRecordEnumPropertyParser, RunningDaysParser>("RunningDaysParser");
            container.RegisterType<IRecordEnumPropertyParser, SeatingClassParser>("SeatingClassParser");
            container.RegisterType<IRecordEnumPropertyParser, SleeperDetailsParser>("SleeperDetailsParser");
            container.RegisterType<IRecordEnumPropertyParser, StpIndicatorParser>("StpIndicatorParser");
            container.RegisterType<IRecordEnumPropertyParser, TransactionTypeParser>("TransactionTypeParser");

            container.RegisterType<ITimingAllowanceParser, TimingAllowanceParser>();
            container.RegisterType<IDateTimeParser, DateTimeParser>();
            
            return container;
        }
    }
}