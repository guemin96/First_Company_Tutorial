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
using static Network_project.Class.SocketInstance;
namespace Network_project.Class
{
    class Broadcast
    {
        Thread send_thread;
        UdpClient send_socket;// 보내는 소켓
        private bool isSend = false;

        Thread recv_thread;
        UdpClient recv_socket;// 받는 소켓
        private bool isConnected = false;
        public bool IsConnected { get { return isConnected; } }

        IPHostEntry myIp;

        IPEndPoint broadcast_ip = new IPEndPoint(IPAddress.Broadcast, 31000);
        IPEndPoint recv_ip = new IPEndPoint(0, 0);// 브로드캐스트로 쏴서 받을때 IP:포트번호 저장하는 변수 서버 IP:PORT
        


        byte[] send_data;
        byte[] recv_data;

        public void startSend()
        {
            isSend = true;
            send_thread = new Thread(broad_do_send);
            send_thread.Start();
        }
        void broad_do_send()
        {
            while (isSend)
            {
                send_socket = new UdpClient();//브로드캐스트를 쏴주는 소켓 설정
                string str = "alive check";
                send_data = Encoding.UTF8.GetBytes(str);
                send_socket.Send(send_data, send_data.Length, broadcast_ip);

                Thread.Sleep(1000);// 1초간 보내는 행위를 멈춰준다.
            }

        }
        public void startReceive()
        {
            recv_socket = new UdpClient(31000);
            recv_thread = new Thread(broad_do_receive);
            recv_thread.Start();
        }
        void broad_do_receive()
        {
            while (isSend)
            {
                recv_data = recv_socket.Receive(ref recv_ip);//브로드캐스트를 쏴서 되받는 IP포트를 recv_ip에 저장한다.

                string str = Encoding.UTF8.GetString(recv_data);
                myIp = Dns.GetHostByName(Dns.GetHostName()); 

                isConnected = recv_ip.Address.ToString() == myIp.AddressList[0].ToString();// 받은 IP가 내 컴퓨터와 동일할 경우에 내 컴퓨터를 서버로 만든다.
                Instance.serverIP = recv_ip;

                isSend = false;
            }
        }
        public void CloseProgram()
        {
            send_socket.Close();
            recv_socket.Close();
        }

    }
}
