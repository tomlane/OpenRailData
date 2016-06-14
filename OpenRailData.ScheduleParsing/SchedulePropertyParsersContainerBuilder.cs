using Microsoft.Practices.Unity;
using OpenRailData.ScheduleParsing.PropertyParsers;

namespace OpenRailData.ScheduleParsing
{
    public static class SchedulePropertyParsersContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

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