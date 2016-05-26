using System;
using System.Linq;
using Apache.NMS;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using OpenRailData.BerthStepData;
using OpenRailData.DataFetcher;
using OpenRailData.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json;
using OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers;
using OpenRailData.TrainMovementParsing;
using OpenRailData.TrainMovementParsing.Json;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Serilog;

namespace OpenRailData.TestConsole
{
    internal static class Program
    {
        private static ITrainMovementMessageParsingService _movementMessageParsingService;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();

            var container = BuildContainer();

            _movementMessageParsingService = container.Resolve<ITrainMovementMessageParsingService>();

            IConnectionFactory factory = new NMSConnectionFactory("stomp:failover:tcp://datafeeds.networkrail.co.uk:61618");

            IConnection connection = factory.CreateConnection("username", "password");
            ISession session = connection.CreateSession();

            IDestination movementDestination = session.GetDestination("topic://TRAIN_MVT_ALL_TOC");
            IMessageConsumer movementConsumer = session.CreateConsumer(movementDestination);
            
            connection.Start();
            movementConsumer.Listener += OnMovementMessage;

            Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

            Console.ReadLine();

            connection.Close();
        }

        private static void OnMovementMessage(IMessage message)
        {
            Console.WriteLine("Median-Server (.NET): Message received");

            try
            {
                ITextMessage msg = (ITextMessage)message;

                message.Acknowledge();

                var array = JArray.Parse(msg.Text).Children().Select(jToken => jToken.ToString());

                _movementMessageParsingService.ParseTrainMovementMessages(array);
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

            return container;
        }
    }

    internal class NetworkRailMessageLog
    {
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{Content}";
        }
    }
}
