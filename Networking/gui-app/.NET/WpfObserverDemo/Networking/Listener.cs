using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public  class Listener :  IMessageListener
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
            Console.WriteLine($"Message Received : {message} [Receiver: PRGM]");
            LatestMessage = message;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
