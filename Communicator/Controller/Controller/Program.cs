using Communicator;

namespace Controller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the various communicator instances.
            ICommunicator tcpCommunicator = new TcpCommunicator();
            ICommunicator udpCommunicator = new UdpCommunicator();


            tcpCommunicator.SendMessage("sample", "sample");
            udpCommunicator.SendMessage("sample1", "sample");

            // Create a list of communicators.
            List<ICommunicator> communicators = new List<ICommunicator>();
            communicators.Add(tcpCommunicator);
            communicators.Add(udpCommunicator);

            // Create a list of messages.
            //List<string> messages = new List<string> {"Good Morning", "Buenos Dia", "Guten Tag"};

            //for (int i = 0; i < communicators.Count; i++)
            //{

            //}
            
        }
    }
}
