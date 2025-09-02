
namespace Networking
{
    public class Communicator : ICommunicator
    {
        FileSystemWatcher _watcher;
        Dictionary<string, IMessageListener> _lookUpTable = new();
        
        public Communicator()
        {
            _watcher = new FileSystemWatcher();
            _watcher.Path = ".\\";
            _watcher.Filter = "in.txt";
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += OnChanged;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = File.ReadLines(e.FullPath).Last();
            //string message = File.ReadAllText(e.FullPath);
            string[] slicedMessage = message.Split(':');
            if (_lookUpTable.Count > 0 && _lookUpTable.ContainsKey(slicedMessage[0]))
            {
                _lookUpTable[slicedMessage[0]].OnMessageReceived(slicedMessage[1]);

            }
        }


        public void SendMessage(string message, string ip)
        {
            File.WriteAllText($".\\{ip}.txt", message);
        }

        public void Subscribe(string id, IMessageListener listener)
        {
            _lookUpTable.Add(id, listener);
        }
    }
}
