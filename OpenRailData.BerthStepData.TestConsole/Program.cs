using System;
using System.Linq;
using Apache.NMS;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OpenRailData.BerthStepData;
using OpenRailData.DataFetcher;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.Domain.TrainMovements;
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
        private static ITrainMovementMessageParsingService _movementMessageParsingService;
        private static ITrainMovementStorageService _movementStorageService;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();

            var container = BuildContainer();

            _movementMessageParsingService = container.Resolve<ITrainMovementMessageParsingService>();
            _movementStorageService = container.Resolve<ITrainMovementStorageService>();
            
            IConnectionFactory factory = new NMSConnectionFactory("stomp:failover:tcp://datafeeds.networkrail.co.uk:61618");

            IConnection connection = factory.CreateConnection("username", "password");

            connection.ConnectionInterruptedListener += ConnectionInterruptedHandler;
            connection.ConnectionResumedListener += ConnectionResumedHandler;
            connection.ExceptionListener += ExceptionHandler;

            ISession session = connection.CreateSession();
            
            ITopic movementTopic = session.GetTopic("topic://TRAIN_MVT_ALL_TOC");
            IMessageConsumer movementConsumer = session.CreateDurableConsumer(movementTopic, "toml-movements", null, false);
            
            connection.Start();
            movementConsumer.Listener += OnMovementMessage;
            
            Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

            Console.ReadLine();

            connection.Close();
        }

        private static void ExceptionHandler(Exception exception)
        {
            Log.Error(exception, string.Empty);
        }

        private static void ConnectionResumedHandler()
        {
            Log.Information("Connection to Network Rail Data Feeds re-established.");
        }

        private static void ConnectionInterruptedHandler()
        {
            Log.Warning("Connection to Network Rail Data Feeds interrupted.");
        }

        private static async void OnMovementMessage(IMessage message)
        {
            Console.WriteLine("Median-Server (.NET): Message received");

            try
            {
                var msg = (ITextMessage)message;

                message.Acknowledge();

                Console.WriteLine(DateTime.Now - msg.NMSTimestamp);

                var array = JArray.Parse(msg.Text).Children().Select(jToken => jToken.ToString());

                var parsedMessages = _movementMessageParsingService.ParseTrainMovementMessages(array);

                await _movementStorageService.StoreTrainMovementMessages(parsedMessages);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
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

            container.RegisterType<ITrainMovementMessageParsingService, TrainMovementMessageParsingService>();

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
            container.RegisterType<ITrainMovementStorageProcessor, TrainReinstatmentStorageProcessor>("TrainReinstatmentStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfOriginStorageProcessor>("ChangeOfOriginStorageProcessor");
            container.RegisterType<ITrainMovementStorageProcessor, ChangeOfIdentityStorageProcessor>("ChangeOfIdentityStorageProcessor");

            container.RegisterType<ITrainDescriberUnitOfWorkFactory, TrainDescriberUnitOfWorkFactory>();
            container.RegisterType<ITrainDescriberUnitOfWork, TrainDescriberUnitOfWork>();
            container.RegisterType<IDbContextFactory<TrainDescriberContext>, TrainDescriberContextFactory>();

            container.RegisterType<ITrainDescriberStorageProcessor, SignalMessageStorageProcessor>("SignalMessageStorageProcessor");
            container.RegisterType<ITrainDescriberStorageProcessor, BerthMessageStorageProcessor>("BerthMessageStorageProcessor");

            container.RegisterType<ITrainDescriberRepository<SignalMessage>, SignalMessageRepository>();
            container.RegisterType<ITrainDescriberRepository<BerthMessage>, BerthMessageRepository>();

            return container;
        }
    }
}
