using Chat;
using Networking;
using Screenshare;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using System.Windows.Media.Imaging;
//using System.Windows.Threading;

namespace ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged, IMessageListener
    {
        /// <summary>
        /// Communication Factory for communicator;
        /// </summary>
        static private readonly CommunicationFactory _communicationFactory = new CommunicationFactory();

        /// <summary>
        /// Latest message and receiver variables.
        /// </summary>
        private string _latestMessage = string.Empty;
        private string _latestReceiver = string.Empty;

        // Image as Bitmap.
        //public BitmapImage? ReceivedImage { get; private set; }

        public string LatestReceiver
        {
            get
            {
                return _latestReceiver;
            }

            private set
            {
                if (value !=  _latestReceiver)
                {
                    _latestReceiver = value;
                    OnPropertyChanged();
                }
            }
        }
        
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

        public MainWindowViewModel() 
        { 
            ICommunicator _communicator = _communicationFactory.GetCommunicator();

            ChatListener chatListener = new ChatListener();
            ScreenshareListener screenshareListener = new ScreenshareListener();
            _communicator.Subscribe("CHAT", chatListener);
            _communicator.Subscribe("SCSR", screenshareListener);


            chatListener.OnChatMessageReceived += delegate (string message)
            {
                // UI element update needs to happen on the UI thread, and this callback is
                // likely run on a worker thread. However we do not need to explicitly
                // dispatch to the UI thread here because OnPropertyChanged event is
                // automatically marshaled to the UI thread. (Courtesy: https://github.com/chittur/distributed-and-gui-demo/blob/master/ViewModel/MainPageViewModel.cs)
                LatestMessage = message;
                LatestReceiver = "CHAT";
                OnPropertyChanged(nameof(LatestMessage));
                OnPropertyChanged(nameof(LatestReceiver));
            };

            //screenshareListener.OnImageMessageReceived += delegate (string imageAsBase64String)
            //{
                // Like mentioned above, OnPropertyChanged event is automatically marshaled
                // to the UI thread. However, the bitmap image has thread affinity and needs
                // to be created on the same thread as it is displayed on (UI thread). Hence
                // let us explicitly dispatch the handling of this message to the UI thread.
                // (Courtesy: https://github.com/chittur/distributed-and-gui-demo/blob/master/ViewModel/MainPageViewModel.cs)
            //    Dispatcher.Invoke((string image) =>
            //    {
            //        ReceivedImage = GetImageSourceFromBase64String(image);
            //        OnPropertyChanged(nameof(ReceivedImage));
            //    },
            //    imageAsBase64String);
            //};

            //Console.WriteLine("check 3...");
            _communicator.Subscribe("MVVM" ,this);
        }

        public void OnMessageReceived(string message)
        {
            LatestMessage = message;
            LatestReceiver = "MVVM";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
