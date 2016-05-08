using System;
using MongoDB.Driver;
using OpenRailData.Configuration;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb
{
    public class MongoDbClientFactory : IMongoDbClientFactory
    {
        private readonly IConfigManager _configManager;

        public MongoDbClientFactory(IConfigManager configManager)
        {
            if (configManager == null)
                throw new ArgumentNullException(nameof(configManager));
            _configManager = configManager;
        }

        public IMongoClient Create()
        {
            return new MongoClient(_configManager.GetConfigSetting("MongoDbConnectionString"));
        }
    }
}