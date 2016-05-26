namespace OpenRailData.Configuration
{
    public interface IConnectionStringProvider
    {
        string ConnectionString(string key);
    }
}
