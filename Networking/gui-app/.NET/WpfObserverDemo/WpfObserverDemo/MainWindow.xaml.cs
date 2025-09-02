using Chat;
using Networking;
using Screenshare;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfObserverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessageListener
    {
        static CommunicationFactory communicationFactory = new CommunicationFactory();
        ICommunicator communicator = communicationFactory.GetCommunicator();
        private static Dispatcher Dispatcher => Application.Current?.Dispatcher ?? Dispatcher.CurrentDispatcher;
        public MainWindow()
        {
            InitializeComponent();
            

            IMessageListener mainListener = new Listener();
            IMessageListener chatListener = new ChatListener();
            IMessageListener screenshareListener = new ScreenshareListener();
            communicator.Subscribe("PRGM", mainListener);
            communicator.Subscribe("CHAT", chatListener);
            communicator.Subscribe("SCSR", screenshareListener);
            communicator.Subscribe("UX", this);

            chatListener.OnChatMessageReceived += delegate (string message)
            {
                Dispatcher.Invoke(() =>
                {
                    ReceivedMessage = message;
                    OnPropertyChanged(nameof(ReceivedMessage));

                }
                );
            };
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string listenerId = ID.Text;
            string content = msgSent.Text;
            string message = listenerId + ":" + content + '\n';
            communicator.SendMessage(message, "out");
            MessageBox.Show("Message sent successfully");
        }

        public void OnMessageReceived(string message)
        {
            Dispatcher.Invoke(() =>
                {
                    receiver.Text = "UX";
                    msgReceived.Text = message;

                }
            );
            Console.WriteLine("in console");
        }
    }
}