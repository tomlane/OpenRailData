using System.Data.Entity.Infrastructure;
using Microsoft.Practices.Unity;
using OpenRailData.Configuration;
using OpenRailData.Modules.ScheduleFetching.Cif;
using OpenRailData.Modules.ScheduleParsing.Cif;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.Modules.ScheduleStorage.EntityFramework;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.UnitOfWork;
using OpenRailData.Modules.ScheduleStorageService;
using OpenRailData.Modules.ScheduleStorageService.RecordStorageProcessor;
using OpenRailData.Modules.ScheduleValidation;
using OpenRailData.ScheduleFetching;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleStorage;
using OpenRailData.ScheduleValidation;

namespace OpenRailData.ScheduleContainer
{
    public static class CifParserIocContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<IScheduleRecordStorageService, ScheduleRecordStorageService>();
            container.RegisterType<IScheduleRecordParsingService, CifScheduleRecordParsingService>();
            container.RegisterType<IScheduleFetchingService, CifScheduleFetchingService>();

            container.RegisterType<IScheduleFileRecordExtractor, ScheduleFileRecordExtractor>();
            container.RegisterType<IScheduleRecordMerger, CifScheduleRecordMerger>();
            container.RegisterType<IScheduleRecordStorageService, ScheduleRecordStorageService>();

            container.RegisterType<IFetchScheduleUrlProvider, CifFetchScheduleUrlProvider>();
            container.RegisterType<IConfigManager, AppSettingsConfigManager>();
            container.RegisterType<IScheduleFileFetcher, WebScheduleFileFetcher>();

            container.RegisterType<IScheduleRecordParser, AssociationCifRecordParser>("AssociationCifRecordParser");
            container.RegisterType<IScheduleRecordParser, BasicScheduleExtraDetailsCifRecordParser>("BasicScheduleExtraDetailsCifRecordParser");
            container.RegisterType<IScheduleRecordParser, ScheduleCifRecordParser>("ScheduleCifRecordParser");
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

            container.RegisterType<IScheduleRecordStorageProcessor, AssociationAmendScheduleRecordStorageProcessor>("AssociationAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, AssociationDeleteScheduleRecordStorageProcessor>("AssociationDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, AssociationInsertScheduleRecordStorageProcessor>("AssociationInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleAmendScheduleRecordStorageProcessor>("ScheduleAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleDeleteScheduleRecordStorageProcessor>("ScheduleDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, ScheduleInsertScheduleRecordStorageProcessor>("ScheduleInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocAmendScheduleRecordStorageProcessor>("TiplocAmendScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocDeleteScheduleRecordStorageProcessor>("TiplocDeleteScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, TiplocInsertScheduleRecordStorageProcessor>("TiplocInsertScheduleRecordStorageProcessor");
            container.RegisterType<IScheduleRecordStorageProcessor, HeaderScheduleRecordStorageProcessor>("HeaderScheduleRecordStorageProcessor");

            container.RegisterType<IHeaderRecordValidator, HeaderRecordValidator>();

            container.RegisterType<IScheduleUnitOfWorkFactory, ScheduleUnitOfWorkFactory>();
            container.RegisterType<IScheduleUnitOfWork, ScheduleUnitOfWork>();

            container.RegisterType<IDbContextFactory<ScheduleContext>, ScheduleContextFactory>();
            
            return container;
        }
    }
}