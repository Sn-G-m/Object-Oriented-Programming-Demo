using Networking;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public delegate void ImageMessageReceived(string imageAsBase64String);

namespace Screenshare
{
    public class ScreenshareListener : IMessageListener
    {
        public event ImageMessageReceived? OnImageMessageReceived;

        public void OnMessageReceived(string message)
        {
            Console.WriteLine($"Message Received : {message} [Receiver: SCSR]");
            OnImageMessageReceived?.Invoke(message);
        }
    }
}
