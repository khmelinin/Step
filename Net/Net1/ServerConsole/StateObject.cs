using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class StateObject
    {
        public Socket socket { get; set; }
        public byte[] buffer { get; set; }
    }
}
