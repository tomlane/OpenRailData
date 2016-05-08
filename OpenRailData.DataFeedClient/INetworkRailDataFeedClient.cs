namespace OpenRailData.DataFeedClient
{
    public interface INetworkRailDataFeedClient
    {
        void Connect();
        void Disconnect();
    }
}