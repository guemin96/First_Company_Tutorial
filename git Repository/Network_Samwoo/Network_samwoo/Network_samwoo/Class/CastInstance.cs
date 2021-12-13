using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_samwoo.Class
{
    public  class CastInstance
    {
        public int Broadcast_Port = 31000;
        public string Broadcast_Address = "192.168.2.255";
        public int Unicast_Port = 31001;
        public string Multicast_Address = "229.1.1.229";
        public int Multicast_Port = 31002;

        private static CastInstance instance;

        public static CastInstance Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new CastInstance();
                }
                return instance;
            }
        }
    }
}
