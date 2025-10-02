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
using ViewModel;

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
            DataContext = new MainWindowViewModel();

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string listenerId = ID.Text;
            string content = msgSent.Text;
            string message = listenerId + ":" + content + '\n';
            communicator.SendMessage(message, "out");
            MessageBox.Show("Message sent successfully");
        }

        //public void OnMessageReceived(string message)
        //{
        //    Dispatcher.Invoke(() =>
        //        {
        //            //msgReceived.Text = message;

        //        }
        //    );
        //    //msgReceived.Text = message;

        //    Console.WriteLine("in console");
        //}
    }
}