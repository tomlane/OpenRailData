using System;
using Apache.NMS;

namespace OpenRailData.Modules.DataFeedClient.OpenWire
{
    public class ConsoleDataFeedMessageProcessor : INetworkRailDataFeedMessageProcessor
    {
        public void ProcessMessage(IMessage message)
        {
            try
            {
                Console.WriteLine("Median-Server (.NET): Message received");

                ITextMessage msg = (ITextMessage)message;
                message.Acknowledge();

                Console.WriteLine(msg.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("---");
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}