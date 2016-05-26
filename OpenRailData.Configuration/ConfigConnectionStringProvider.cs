using System.Configuration;

namespace OpenRailData.Configuration
{
    public class ConfigConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] == null)
                throw new ConfigurationErrorsException
                    ($"Connection string with key '{key}' not defined in configuration file");

            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
