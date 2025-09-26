using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chat;
using Networking;
using Screenshare;

namespace ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged, IMessageListener
    {
        static private readonly CommunicationFactory _communicationFactory = new CommunicationFactory();
        private string _latestMessage = string.Empty;
        
        public string LatestMessage
        {
            get
            {
                Console.WriteLine("check 4 mvvm...");
                return _latestMessage;
            }

            private set
            {
                if (value != _latestMessage)
                {
                    Console.WriteLine("check 5 m...");
                    _latestMessage = value;
                    OnPropertyChanged();
                    Console.WriteLine("check 6 m...");
                }
            }
        }

        public MainWindowViewModel() 
        { 
            ICommunicator _communicator = _communicationFactory.GetCommunicator();

            IMessageListener chatListener = new ChatListener();
            IMessageListener screenshareListener = new ScreenshareListener();
            _communicator.Subscribe("CHAT", chatListener);
            _communicator.Subscribe("SCSR", screenshareListener);
            //chatListener.OnChatMessageReceived += delegate (string message)
            //{
            //    // UI element update needs to happen on the UI thread, and this callback is
            //    // likely run on a worker thread. However we do not need to explicitly
            //    // dispatch to the UI thread here because OnPropertyChanged event is
            //    // automatically marshaled to the UI thread.
            //    ReceivedMessage = message;
            //    OnPropertyChanged(nameof(ReceivedMessage));
            //};

            //Console.WriteLine("check 3...");
            _communicator.Subscribe("MVVM" ,this);
        }

        public void OnMessageReceived(string message)
        {
            Console.WriteLine("check 2 m...");
            LatestMessage = message;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            Console.WriteLine("check 1 m...");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
