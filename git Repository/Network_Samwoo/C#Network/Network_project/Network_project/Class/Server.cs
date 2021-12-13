using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_project.Class
{
    class Server
    {
        UdpClient Server_socket;

        IPEndPoint serv_IP = new IPEndPoint(0, 0); //서버 IP 저장
        IPEndPoint recv_IP = new IPEndPoint(0, 0);//클라이언트로부터 받을 IP 

        Thread recv_thread;
        Thread send_thread;

        
        public void setServer(IPEndPoint ipe)
        {
            serv_IP = ipe;
        }

    }
}
