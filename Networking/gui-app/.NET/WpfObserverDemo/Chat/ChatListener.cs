using Networking;

namespace Chat;

public delegate void ChatMessageReceived(string message);

public class ChatListener : IMessageListener
{
    public event ChatMessageReceived? OnChatMessageReceived;
    public void OnMessageReceived(string message)
    {
        Console.WriteLine($"Message Received : {message} [Receiver: CHAT]");
        OnChatMessageReceived?.Invoke(message);
    }
}

