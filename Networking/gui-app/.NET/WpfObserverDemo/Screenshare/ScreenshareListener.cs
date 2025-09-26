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
                Console.WriteLine("check 6...");
                return _latestMessage;
            }

            private set
            {
                if (value != _latestMessage)
                {
                    _latestMessage = value;
                    Console.WriteLine("check 4...");
                    OnPropertyChanged();
                    Console.WriteLine("check 5...");
                }
            }
        }

        public void OnMessageReceived(string message)
        {
            Console.WriteLine($"Message Received : {message} [Receiver: SCSR]");
            Console.WriteLine("check 3...");
            LatestMessage = message;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            Console.WriteLine("check 1...");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine("check 2...");
        }
    }
}
