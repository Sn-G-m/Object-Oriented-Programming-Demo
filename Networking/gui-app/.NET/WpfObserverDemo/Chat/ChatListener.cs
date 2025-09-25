using Networking;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chat;

//public delegate void ChatMessageReceived(string message);

public class ChatListener : INotifyPropertyChanged, IMessageListener
{

    private string _latestMessage = string.Empty;

    public string LatestMessage
    {
        get
        {
            return _latestMessage;
        }

        private set
        {
            if (value != _latestMessage)
            {
                _latestMessage = value;
                OnPropertyChanged();
            }
        }
    }

    //public event ChatMessageReceived? OnChatMessageReceived;
    
    public void OnMessageReceived(string message)
    {
        //Console.WriteLine($"Message Received : {message} [Receiver: CHAT]");
        //OnChatMessageReceived?.Invoke(message);
        LatestMessage = message;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

