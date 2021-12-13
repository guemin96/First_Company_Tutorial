using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_project.Class
{
    class SocketInstance
    {
        public string OWN_ADDRESS = "";
        public int BROADCAST_PORT = 31000;
        public int UNICAST_PORT = 31001;
        public string MULTICAST_ADDRESS = "224.0.1.0";
        public int MULTICAST_PORT = 31002;
        public IPEndPoint serverIP;
        public string chat;

        private static SocketInstance instance;
        public static SocketInstance Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new SocketInstance(); 
                }
                return instance;
            }
        }
    }
}
