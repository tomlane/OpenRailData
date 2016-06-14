using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Apache.NMS;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OpenRailData.BerthStepData;
using OpenRailData.DataFetcher;
using OpenRailData.Logging;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using OpenRailData.ScheduleParsing.PropertyParsers;
using OpenRailData.ScheduleStorage;
using OpenRailData.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json;
using OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers;
using OpenRailData.TrainMovementParsing;
using OpenRailData.TrainMovementParsing.Json;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using OpenRailData.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework;
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
            var timer = new Stopwatch();

            timer.Start();

            var container = BuildContainer();

            _logger = container.Resolve<ILogger>();

            var scheduleParsingService = container.Resolve<IScheduleRecordParsingService>();
            var scheduleStorageService = container.Resolve<IScheduleRecordStorageService>();

            var records = File.ReadLines(@"C:\RailData\JSON Extracts\CIF_EF_TOC_FULL_DAILY%2Ftoc-full");

            var result = scheduleParsingService.ParseScheduleRecords(records);

            Console.WriteLine("Records Parsed");
            Console.WriteLine(timer.Elapsed);

            scheduleStorageService.StoreScheduleRecords(result);

            timer.Stop();
            
            Console.WriteLine(timer.Elapsed);

            Console.ReadLine();
            
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

            //Console.ReadLine();

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
            
            

            container.RegisterInstance<ILogger>(ConsoleLoggerConfig.Create());

            // schedule json testing
            

            

            return container;
        }
    }
}
