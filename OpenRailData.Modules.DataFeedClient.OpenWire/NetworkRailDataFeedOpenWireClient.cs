using System;
using Apache.NMS;
using OpenRailData.Configuration;
using OpenRailData.DataFeedClient;

namespace OpenRailData.Modules.DataFeedClient.OpenWire
{
    public class NetworkRailDataFeedOpenWireClient : INetworkRailDataFeedClient
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly INetworkRailDataFeedMessageProcessor _messageProcessor;
        private readonly IConfigManager _configManager;

        private IConnection _connection;
        private ISession _session;
        private IDestination _destination;
        private IMessageConsumer _consumer;

        public NetworkRailDataFeedOpenWireClient(IConnectionFactoryFactory connectionFactoryFactory, INetworkRailDataFeedMessageProcessor messageProcessor, IConfigManager configManager)
        {
            if (connectionFactoryFactory == null)
                throw new ArgumentNullException(nameof(connectionFactoryFactory));
            if (messageProcessor == null)
                throw new ArgumentNullException(nameof(messageProcessor));
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));

            _connectionFactory = connectionFactoryFactory.Create();
            _messageProcessor = messageProcessor;
            _configManager = configManager;
        }

        public void Connect()
        {
            _connection = _connectionFactory.CreateConnection(_configManager.GetConfigSetting("NetworkRailClientUsername"), _configManager.GetConfigSetting("NetworkRailClientPassword"));
            _session = _connection.CreateSession();

            _destination = _session.GetDestination(_configManager.GetConfigSetting("NetworkRailClientTopic"));
            _consumer = _session.CreateConsumer(_destination);

            _connection.Start();

            _consumer.Listener += _messageProcessor.ProcessMessage;
        }

        public void Disconnect()
        {
            _connection.Close();
        }
    }
}