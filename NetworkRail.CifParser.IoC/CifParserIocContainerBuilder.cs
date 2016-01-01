using Microsoft.Practices.Unity;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.IoC
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

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

            container.RegisterType<IOperatingCharacteristicsParser, OperatingCharacteristicsParser>();
            container.RegisterType<ILocationActivityParser, LocationActivityParser>();

            return container;
        }
    }
}