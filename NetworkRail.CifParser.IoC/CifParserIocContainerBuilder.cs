using Microsoft.Practices.Unity;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.JsonRecordParsers;
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

            container.RegisterType<IScheduleRecordParser, AssociationCifRecordParser>("AssociationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, BasicScheduleExtraDetailsCifRecordParser>("BasicScheduleExtraDetailsCifRecordParser");
            container.RegisterType<IScheduleRecordParser, BasicScheduleCifRecordParser>("BasicScheduleCifRecordParser");
            container.RegisterType<IScheduleRecordParser, ChangesEnRouteCifRecordParser>("ChangesEnRouteCifRecordParser");
            container.RegisterType<IScheduleRecordParser, HeaderCifRecordParser>("HeaderCifRecordParser");
            container.RegisterType<IScheduleRecordParser, HeaderJsonRecordParser>("HeaderJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, OriginLocationCifRecordParser>("OriginLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, IntermediateLocationCifRecordParser>("IntermediateLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TerminatingLocationCifRecordParser>("TerminatingLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocDeleteCifRecordParser>("TiplocDeleteCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocInsertCifRecordParser>("TiplocInsertCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocAmendCifRecordParser>("TiplocAmendCifRecordParser");
            
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