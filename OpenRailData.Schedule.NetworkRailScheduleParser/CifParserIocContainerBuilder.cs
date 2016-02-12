using Microsoft.Practices.Unity;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleManager, CifScheduleManager>();

            container.RegisterType<IScheduleReader, FileScheduleReader>();
            container.RegisterType<IScheduleFileParser, CifScheduleFileParser>();
            container.RegisterType<IScheduleRecordMerger, CifScheduleRecordMerger>();

            container.RegisterType<IFetchScheduleUrlProvider, CifFetchScheduleUrlProvider>();
            container.RegisterType<IConfigManager, AppSettingsConfigManager>();
            container.RegisterType<IScheduleFileFetcher, WebScheduleFileFetcher>();

            container.RegisterType<IScheduleRecordParser, AssociationCifRecordParser>("AssociationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, BasicScheduleExtraDetailsCifRecordParser>("BasicScheduleExtraDetailsCifRecordParser");
            container.RegisterType<IScheduleRecordParser, BasicScheduleCifRecordParser>("BasicScheduleCifRecordParser");
            container.RegisterType<IScheduleRecordParser, ChangesEnRouteCifRecordParser>("ChangesEnRouteCifRecordParser");
            container.RegisterType<IScheduleRecordParser, HeaderCifRecordParser>("HeaderCifRecordParser");
            container.RegisterType<IScheduleRecordParser, OriginLocationCifRecordParser>("OriginLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, IntermediateLocationCifRecordParser>("IntermediateLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TerminatingLocationCifRecordParser>("TerminatingLocationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocDeleteCifRecordParser>("TiplocDeleteCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocInsertCifRecordParser>("TiplocInsertCifRecordParser");
            container.RegisterType<IScheduleRecordParser, TiplocAmendCifRecordParser>("TiplocAmendCifRecordParser");
            container.RegisterType<IScheduleRecordParser, EndOfFileRecordParser>("EndOfFileRecordParser");
            
            container.RegisterType<IRecordEnumPropertyParser, AssociationCategoryParser>("AssociationCategoryParser");
            container.RegisterType<IRecordEnumPropertyParser, AssociationTypeParser>("AssociationTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, BankHolidayRunningParser>("BankHolidayRunningParser");
            container.RegisterType<IRecordEnumPropertyParser, CateringCodeParser>("CateringCodeParser");
            container.RegisterType<IRecordEnumPropertyParser, DateIndicatorParser>("DateIndicatorParser");
            container.RegisterType<IRecordEnumPropertyParser, ExtractUpdateTypeParser>("ExtractUpdateTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, LocationActivityParser>("LocationActivityParser");
            container.RegisterType<IRecordEnumPropertyParser, OperatingCharacteristicsParser>("OperatingCharacteristicsParser");
            container.RegisterType<IRecordEnumPropertyParser, PowerTypeParser>("PowerTypeParser");
            container.RegisterType<IRecordEnumPropertyParser, ReservationDetailsParser>("ReservationDetailsParser");
            container.RegisterType<IRecordEnumPropertyParser, RunningDaysParser>("RunningDaysParser");
            container.RegisterType<IRecordEnumPropertyParser, ScheduleRecordTypeParser>("ScheduleRecordTypeParser");
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