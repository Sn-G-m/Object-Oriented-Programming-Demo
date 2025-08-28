using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Networking;
using Screenshare;
using Chat;

namespace WpfObserverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static CommunicationFactory communicationFactory = new CommunicationFactory();
        ICommunicator communicator = communicationFactory.GetCommunicator();
        public MainWindow()
        {
            InitializeComponent();
            

            IMessageListener mainListener = new Listener();
            IMessageListener chatListener = new ChatListener();
            IMessageListener screenshareListener = new ScreenshareListener();
            communicator.Subscribe("PRGM", mainListener);
            communicator.Subscribe("CHAT", chatListener);
            communicator.Subscribe("SCSR", screenshareListener);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string listenerId = ID.Text;
            string content = msgSent.Text;
            string message = listenerId + ":" + content + '\n';
            communicator.SendMessage(message, "127.0.0.1");
            MessageBox.Show("Message sent successfully");
        }
    }
}