using Apache.NMS;

namespace OpenRailData.Modules.DataFeedClient.OpenWire
{
    public interface IConnectionFactoryFactory
    {
        IConnectionFactory Create();
    }
}