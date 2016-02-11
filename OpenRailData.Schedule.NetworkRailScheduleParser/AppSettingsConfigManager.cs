using System;
using System.Collections.Generic;
using System.Configuration;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class AppSettingsConfigManager : IConfigManager
    {
        public string GetConfigSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            string setting = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(setting))
                throw new KeyNotFoundException(key);

            return setting;
        }
    }
}