using System;
using Apache.NMS;
using OpenRailData.Configuration;

namespace OpenRailData.Modules.DataFeedClient.OpenWire
{
    public class NmsConnectionFactoryFactory : IConnectionFactoryFactory
    {
        private readonly IConfigManager _configManager;

        public NmsConnectionFactoryFactory(IConfigManager configManager)
        {
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));

            _configManager = configManager;
        }

        public IConnectionFactory Create()
        {
            return new NMSConnectionFactory(_configManager.GetConfigSetting("NetworkRailFeedUrl"));
        }
    }
}