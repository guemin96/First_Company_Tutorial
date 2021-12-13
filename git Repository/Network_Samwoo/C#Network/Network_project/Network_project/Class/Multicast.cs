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
using Network_project.Class;
using static Network_project.Class.SocketInstance;
namespace Network_project.Class
{

    class Multicast
    {
        Thread client_send_thread;
        UdpClient client_send_socket;// 보내는 소켓
        byte[] client_send_data;

        Thread client_recv_thread;
        UdpClient client_recv_socket;// 받는 소켓
        byte[] client_recv_data;
        
        Thread server_recv_thread;
        UdpClient server_recv_socket;// 받는 소켓
        byte[] server_recv_data;

        Thread server_send_thread;
        UdpClient server_send_socket;// 보내는 소켓
        byte[] server_send_data;

        public delegate void ChatTxt(string data);


        public delegate void ChatLogHandler(string data);
        event ChatLogHandler ChatLogEvent;
        
        Form1 m_form;
        Multicast(Form1 _form)
        {
            m_form = _form;

            ChatLogEvent += new ChatLogHandler(m_form.AddText);
        }

        public Multicast()
        {
        }


        private bool isConnected = false;
        public bool IsConnected { get { return isConnected; } }


        //채팅


        IPHostEntry myIp;
    
        IPEndPoint recv_ip = new IPEndPoint(0, 0);// 멀티캐스트로 쏴서 받을때 IP:포트번호 저장하는 변수 서버 IP:PORT


        public void StartCliSendMsg()
        {
            client_send_socket = new UdpClient(31002);
            client_send_thread = new Thread(cli_do_send);
            client_send_thread.Start();
        }
        void cli_do_send()
        {
            while (true)
            {
                client_send_socket = new UdpClient();//멀티캐스트로 서버ip로 데이터를 쏴주는 역할
                
                //client_send_data = Encoding.UTF8.GetBytes(str);
                IPEndPoint serverIP = new IPEndPoint(Instance.serverIP.Address, 31002);// server ip:포트

                client_send_socket.Send(client_send_data, client_send_data.Length, serverIP);//저장해둔 serverIP로 보냄
            }
        }
       
        public void StartServerSendRecvMsg()
        {
            server_recv_socket = new UdpClient();
            server_recv_thread = new Thread(ser_do_Sendreceive);
            server_recv_thread.Start();
        }
        void ser_do_Sendreceive()
        {
            while(true)
            {
                server_recv_data = server_recv_socket.Receive(ref recv_ip); // clientip를 저장해두는 곳

                server_send_socket.Send(server_recv_data, server_recv_data.Length, recv_ip); //clientip로 보내줌
            }
        }
        public void StartcliReceiveMsg()
        {
            client_recv_socket = new UdpClient();
            client_recv_thread = new Thread(cli_do_receive);
            client_recv_thread.Start();
        }
        void cli_do_receive()
        {
            while (true)
            {
                client_recv_data = client_recv_socket.Receive(ref recv_ip);
                //chatlog.M_form.lbxView.Items.Add(Encoding.UTF8.GetString(client_recv_data));
            }
        }
    }
}
