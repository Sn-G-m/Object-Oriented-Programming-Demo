using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class CommunicationFactory
    {
        public ICommunicator GetCommunicator()
        { 
            return new Communicator();
        }
    }
}
