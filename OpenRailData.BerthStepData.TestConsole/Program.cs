using System;
using System.IO;
using System.Linq;
using Apache.NMS;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OpenRailData.BerthStepData;
using OpenRailData.DataFetcher;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Logging;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Modules.ScheduleStorage.EntityFramework;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.UnitOfWork;
using OpenRailData.Modules.ScheduleStorageService;
using OpenRailData.Modules.ScheduleStorageService.RecordStorageProcessor;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using OpenRailData.ScheduleStorage;
using OpenRailData.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json;
using OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers;
using OpenRailData.TrainDescriberStorage;
using OpenRailData.TrainDescriberStorage.EntityFramework;
using OpenRailData.TrainDescriberStorage.EntityFramework.Repository;
using OpenRailData.TrainDescriberStorage.EntityFramework.StorageProcessor;
using OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork;
using OpenRailData.TrainMovementParsing;
using OpenRailData.TrainMovementParsing.Json;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using OpenRailData.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework;
using OpenRailData.TrainMovementStorage.EntityFramework.Repository;
using OpenRailData.TrainMovementStorage.EntityFramework.StorageProcessor;
using OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork;
using Serilog;

namespace OpenRailData.TestConsole
{
    internal static class Program
    {
        private static ITrainMovementParsingService _movementParsingService;
        private static ITrainMovementStorageService _movementStorageService;

        private static ILogger _logger;

        static void Main(string[] args)
        {
            var container = BuildContainer();

            _logger = container.Resolve<ILogger>();

            var scheduleParsingService = container.Resolve<IScheduleRecordParsingService>();
            var scheduleStorageService = container.Resolve<IScheduleRecordStorageService>();

            var records = File.ReadLines(@"C:\RailData\JSON Extracts\CIF_EF_TOC_FULL_DAILY-toc-full");

            var result = scheduleParsingService.ParseScheduleRecords(records);

            Console.WriteLine("Records Parsed");

            scheduleStorageService.StoreScheduleRecords(result);

            //_movementParsingService = container.Resolve<ITrainMovementParsingService>();
            //_movementStorageService = container.Resolve<ITrainMovementStorageService>();

            //IConnectionFactory factory = new NMSConnectionFactory("stomp:failover:tcp://datafeeds.networkrail.co.uk:61618");

            //IConnection connection = factory.CreateConnection("username", "password");

            //connection.ConnectionInterruptedListener += ConnectionInterruptedHandler;
            //connection.ConnectionResumedListener += ConnectionResumedHandler;
            //connection.ExceptionListener += ExceptionHandler;

            //ISession session = connection.CreateSession();

            //ITopic movementTopic = session.GetTopic("topic://TRAIN_MVT_ALL_TOC");
            //IMessageConsumer movementConsumer = session.CreateDurableConsumer(movementTopic, "rde-movements", null, false);

            //connection.Start();
            //movementConsumer.Listener += OnMovementMessage;

            //Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

            Console.ReadLine();

            //connection.Close();
        }

        private static void ExceptionHandler(Exception exception)
        {
            _logger.Error(exception, string.Empty);
        }

        private static void ConnectionResumedHandler()
        {
            _logger.Information("Connection to Network Rail Data Feeds re-established.");
        }

        private static void ConnectionInterruptedHandler()
        {
            _logger.Warning("Connection to Network Rail Data Feeds interrupted.");
        }

        private static async void OnMovementMessage(IMessage message)
        {
            try
            {
                var msg = (ITextMessage)message;

                message.Acknowledge();

                var delay = DateTime.Now - msg.NMSTimestamp;

                _logger.Debug("Current message delivery delay: {delay}", delay);
                
                var array = JArray.Parse(msg.Text).Children().Select(jToken => jToken.ToString());

                var parsedMessages = _movementParsingService.ParseTrainMovementMessages(array);

                await _movementStorageService.StoreTrainMovementMessages(parsedMessages);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, string.Empty);
            }
        }

        private static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBerthStepDataProvider, BerthStepDataProvider>();

            container.RegisterType<IDataFileFetcher, FileSystemDataFileFetcher>();
            container.RegisterType<IDataFileDecompressor, GzipDataFileDecompressor>();

            container.RegisterType<ITrainDescriberMessageParsingService, TrainDescriberMessageParsingService>();

            container.RegisterType<ITrainDescriberMessageParser, BerthCancelMessageParser>("BerthCancelMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, BerthInterposeMessageParser>("BerthInterposeMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, BerthStepMessageParser>("BerthStepMessageParser");

            container.RegisterType<ITrainDescriberMessageParser, SignallingUpdateMessageParser>("SignallingUpdateMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, SignallingRefreshMessageParser>("SignallingRefreshMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, SignallingRefreshFinishedMessageParser>("SignallingRefreshFinishedMessageParser");

            container.RegisterType<ITrainMovementParsingService, TrainMovementParsingService>();

            container.RegisterType<ITrainMovementMessageParser, TrainActivationMessageParser>("TrainActivationMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainCancellationMessageParser>("TrainCancellationMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainMovementMessageParser>("TrainMovementMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainReinstatementMessageParser>("TrainReinstatementMessageParser");
            container.RegisterType<ITrainMovementMessageParser, ChangeOfOriginMessageParser>("ChangeOfOriginMessageParser");
            container.RegisterType<ITrainMovementMessageParser, ChangeOfIdentityMessageParser>("ChangeOfIdentityMessageParser");

            container.RegisterType<ITrainMovementStorageService, TrainMovementStorageService>();
            container.RegisterType<ITrainDescriberStorageService, TrainDescriberStorageService>();

            container.RegisterType<ITrainMovementUnitOfWorkFactory, TrainMovementUnitOfWorkFactory>();
            container.RegisterType<ITrainMovementUnitOfWork, TrainMovementUnitOfWork>();
            container.RegisterType<IDbContextFactory<TrainMovementContext>, TrainMovementContextFactory>();

            container.RegisterType<ITrainMovementRepository<TrainActivation>, TrainActivationRepository>();
            container.RegisterType<ITrainMovementRepository<TrainCancellation>, TrainCancellationRepository>();
            container.RegisterType<ITrainMovementRepository<TrainMovement>, TrainMovementRepository>();
            container.RegisterType<ITrainMovementRepository<TrainReinstatement>, TrainReinstatementRepository>();
            container.RegisterType<ITrainMovementRepository<ChangeOfOrigin>, ChangeOfOriginRepository>();
            container.RegisterType<ITrainMovementRepository<ChangeOfIdentity>, ChangeOfIdentityRepository>();

            container.RegisterType<ITrainMovementStorageProcessor, TrainActivationStorageProcessor>("TrainActivationStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainCancellationStorageProcessor>("TrainCancellationStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainMovementStorageProcessor>("TrainMovementStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, TrainReinstatmentStorageProcessor>("TrainReinstatementStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfOriginStorageProcessor>("ChangeOfOriginStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfIdentityStorageProcessor>("ChangeOfIdentityStorageProcessor");

            container.RegisterType<ITrainDescriberUnitOfWorkFactory, TrainDescriberUnitOfWorkFactory>();
            container.RegisterType<ITrainDescriberUnitOfWork, TrainDescriberUnitOfWork>();
            container.RegisterType<IDbContextFactory<TrainDescriberContext>, TrainDescriberContextFactory>();

            container.RegisterType<ITrainDescriberStorageProcessor, SignalMessageStorageProcessor>("SignalMessageStorageProcessor");
            container.RegisterType<ITrainDescriberStorageProcessor, BerthMessageStorageProcessor>("BerthMessageStorageProcessor");

            container.RegisterType<ITrainDescriberRepository<SignalMessage>, SignalMessageRepository>();
            container.RegisterType<ITrainDescriberRepository<BerthMessage>, BerthMessageRepository>();

            container.RegisterInstance<ILogger>(ConsoleLoggerConfig.Create());

            // schedule json testing
            container.RegisterType<IScheduleRecordParsingService, JsonScheduleRecordParsingService>();

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

            container.RegisterType<IScheduleRecordParser, JsonAssociationRecordParser>("AssociationJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonScheduleRecordParser>("ScheduleJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonHeaderRecordParser>("HeaderJsonRecordParser");
            container.RegisterType<IScheduleRecordParser, JsonTiplocRecordParser>("TiplocJsonRecordParser");

            container.RegisterType<ITimingAllowanceParser, TimingAllowanceParser>();

            container.RegisterType<IScheduleRecordStorageService, ScheduleRecordStorageService>();

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

            container.RegisterType<IScheduleUnitOfWorkFactory, ScheduleUnitOfWorkFactory>();
            container.RegisterType<IScheduleUnitOfWork, ScheduleUnitOfWork>();

            container.RegisterType<IDbContextFactory<ScheduleContext>, ScheduleContextFactory>();

            return container;
        }
    }
}
