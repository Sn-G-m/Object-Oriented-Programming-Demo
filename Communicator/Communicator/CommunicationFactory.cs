using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator
{
    public class CommunicationFactory
    {
        ICommunicator communicator = null;
        public ICommunicator GetCommunicator(bool reliableRequired)
        {   
            if (reliableRequired == true)
            { 
                communicator = new TcpCommunicator();
            }
            else
            {
                communicator = new UdpCommunicator();
            }
            return communicator;
        }
    }
}
