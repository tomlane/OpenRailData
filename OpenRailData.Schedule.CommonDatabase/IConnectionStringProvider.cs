namespace OpenRailData.Schedule.CommonDatabase
{
    public interface IConnectionStringProvider
    {
        string ConnectionString(string key);
    }
}
