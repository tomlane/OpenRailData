using Apache.NMS;

namespace OpenRailData.Modules.DataFeedClient.OpenWire
{
    public interface INetworkRailDataFeedMessageProcessor
    {
        void ProcessMessage(IMessage message);
    }
}