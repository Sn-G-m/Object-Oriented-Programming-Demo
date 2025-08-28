using Networking;
using Screenshare;
using Chat;

namespace Executive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICommunicator communicator = new Communicator();
            communicator.SendMessage("Test Message", "127.0.0.1");
            Console.WriteLine("Message sent successfully.");

            IMessageListener mainListener = new Listener();
            IMessageListener chatListener = new ChatListener();
            IMessageListener screenshareListener = new ScreenshareListener();
            communicator.Subscribe("PRGM", mainListener);
            communicator.Subscribe("CHAT", chatListener);
            communicator.Subscribe("SCSR", screenshareListener);
            Console.WriteLine("All Listeners subscribed successfully. Waiting for messages...");
            Console.ReadKey();
        }
    }
}
