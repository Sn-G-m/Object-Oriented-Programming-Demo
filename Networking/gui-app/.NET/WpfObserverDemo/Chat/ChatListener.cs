using Networking;

namespace Chat
{
    public class ChatListener : IMessageListener
    {
        public void OnMessageReceived(string message)
        {
            Console.WriteLine($"Message Received : {message} [Receiver: CHAT]");
        }
    }
}
