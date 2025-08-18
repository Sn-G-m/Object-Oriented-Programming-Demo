using Communicator;

namespace Controller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a reliable flag for TCP/UDP selection
            bool reliableRequired = true;

            // Create the various communicator instances.
            CommunicationFactory factory = new CommunicationFactory();
            ICommunicator facTCommunicator = factory.GetCommunicator(reliableRequired);
            ICommunicator facFCommunicator = factory.GetCommunicator(!reliableRequired);
            ICommunicator tcpCommunicator = new TcpCommunicator();
            ICommunicator udpCommunicator = new UdpCommunicator();
            ICommunicator rpcCommunicator = new RpcCommunicator();

            // Create a list of communicators.
            List<ICommunicator> communicators = new List<ICommunicator>();
            communicators.Add(facTCommunicator);
            communicators.Add(facFCommunicator);
            communicators.Add(tcpCommunicator);
            communicators.Add(udpCommunicator);
            communicators.Add(rpcCommunicator);

            // Create a list of messages.
            List<string> messages = new List<string> { "Good Day", "Buona Giornata", "Buenos Dia", "Guten Tag", "Dydd Da" };

            for (int i = 0; i < communicators.Count; i++)
            {
                Console.WriteLine($"Using {communicators[i].GetCommunicatorName()}");
                communicators[i].SendMessage(messages[i], "127.0.0.1");
                Console.WriteLine("Communication link closed\n");
            }

        }
    }
}
