using System;
using System.Diagnostics;
using Apache.NMS;
using Microsoft.Practices.Unity;
using OpenRailData.Logging;
using OpenRailData.TrainMovementParsing.Json;
using OpenRailData.TrainMovementStorage.EntityFramework;
using Serilog;

namespace OpenRailData.TestConsole
{
    internal static class Program
    {
        private static ILogger _logger;

        static void Main(string[] args)
        {
            var timer = new Stopwatch();

            timer.Start();

            var container = JsonTrainMovementParserContainerBuilder.Build();
            container = EntityFrameworkTrainMovementStorageContainerBuilder.Build(container);
            container.RegisterInstance(ConsoleLoggerConfig.Create());

            _logger = container.Resolve<ILogger>();

            IConnectionFactory factory = new NMSConnectionFactory("stomp:failover:tcp://datafeeds.networkrail.co.uk:61618");

            IConnection connection = factory.CreateConnection("username", "password");

            connection.ConnectionInterruptedListener += ConnectionInterruptedHandler;
            connection.ConnectionResumedListener += ConnectionResumedHandler;
            connection.ExceptionListener += ExceptionHandler;

            ISession session = connection.CreateSession();

            ITopic movementTopic = session.GetTopic("topic://TRAIN_MVT_ALL_TOC");
            IMessageConsumer movementConsumer = session.CreateDurableConsumer(movementTopic, "rde-movements", null, false);

            connection.Start();
            movementConsumer.Listener += OnMovementMessage;

            Console.WriteLine("Consumer started, waiting for messages... (Press ENTER to stop.)");

            Console.ReadLine();

            connection.Close();
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

        private static void OnMovementMessage(IMessage message)
        {
            try
            {
                var msg = (ITextMessage)message;

                message.Acknowledge();

                var delay = DateTime.Now - msg.NMSTimestamp;

                _logger.Information("Current message delivery delay: {delay}", delay);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, string.Empty);
            }
        }
    }
}
