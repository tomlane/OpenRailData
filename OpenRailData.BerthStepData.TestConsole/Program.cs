using System;
using Apache.NMS;
using Microsoft.Practices.Unity;
using OpenRailData.BerthStepData;
using OpenRailData.DataFetcher;
using OpenRailData.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json;
using OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers;
using Serilog;

namespace OpenRailData.TestConsole
{
    internal static class Program
    {
        private static ILogger _logger;

        static void Main(string[] args)
        {
            _logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();

            IConnectionFactory factory = new NMSConnectionFactory(new Uri("tcp://datafeeds.networkrail.co.uk:61619"));

            IConnection connection = factory.CreateConnection("username", "password");
            ISession session = connection.CreateSession();

            IDestination movementDestination = session.GetDestination("topic://TRAIN_MVT_ALL_TOC");
            IMessageConsumer movementConsumer = session.CreateConsumer(movementDestination);

            IDestination vstpDestination = session.GetDestination("topic://VSTP_ALL");
            IMessageConsumer vstpConsumer = session.CreateConsumer(vstpDestination);
            
            connection.Start();
            movementConsumer.Listener += OnMessage;
            vstpConsumer.Listener += OnMessage;

            Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

            Console.ReadLine();
            connection.Close();
        }

        private static void OnMessage(IMessage message)
        {
            try
            {
                Console.WriteLine("Median-Server (.NET): Message received");

                ITextMessage msg = (ITextMessage)message;

                message.Acknowledge();

                var messageLog = new NetworkRailMessageLog
                {
                    Content = msg.Text.Replace(@"\","")
                };
                
                _logger.Information(messageLog.Content);
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
