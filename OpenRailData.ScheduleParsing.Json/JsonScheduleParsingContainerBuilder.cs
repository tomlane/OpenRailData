using Microsoft.Practices.Unity;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using OpenRailData.ScheduleParsing.PropertyParsers;

namespace OpenRailData.ScheduleParsing.Json
{
    public static class JsonScheduleParsingContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleRecordParsingService, JsonScheduleRecordParsingService>();

            container.RegisterType<IScheduleRecordParser, JsonAssociationRecordParser>("AssociationJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonScheduleRecordParser>("ScheduleJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonHeaderRecordParser>("HeaderJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonTiplocRecordParser>("TiplocJsonRecordParser");

            container.RegisterType<ITimingAllowanceParser, TimingAllowanceParser>();

            return container;
        }
    }
}