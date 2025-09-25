using Networking;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Screenshare
{
    public class ScreenshareListener : INotifyPropertyChanged, IMessageListener
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
        public void OnMessageReceived(string message)
        {
            Console.WriteLine($"Message Received : {message} [Receiver: SCSR]");
            LatestMessage = message;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
