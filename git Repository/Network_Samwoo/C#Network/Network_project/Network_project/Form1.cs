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

namespace Network_project
{
    public partial class Form1 : Form
    {
        Broadcast broadcast = new Broadcast();
        Server server = new Server();
       // Multicast multicast;

        Thread send_thread;
        UdpClient send_soc;// 보내는 소켓
        byte[] send_data;

        Thread ser_send_thread;
        UdpClient ser_send_soc;// 보내는 소켓
        byte[] ser_send_data;

        Thread recv_thread;
        UdpClient recv_soc;// 받는 소켓
        byte[] recv_data;

        Thread Cli_recv_thread;
        UdpClient Cli_recv_soc;// 받는 소켓
        byte[] Cli_recv_data;


        IPEndPoint recv_ip = new IPEndPoint(0, 0),// 멀티캐스트로 쏴서 받을때 IP:포트번호 저장하는 변수 서버 IP:PORT
            multicast_iep = new IPEndPoint(IPAddress.Parse("224.0.1.0"), 31002) ;
        IPAddress multicast_IP = IPAddress.Parse("224.0.1.0");


        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            broadcast.startSend();
            broadcast.startReceive();

            if (!broadcast.IsConnected)
                AddText("서버가 없습니다. 서버를 구축하겠습니다.");
            else
                AddText("서버와 연결했습니다. 클라이언트를 생성합니다.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            broadcast.CloseProgram();
            Close();
        }

        public void AddText(string _text)
        {
            lbxView.Items.Add(_text);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (broadcast.IsConnected)
            {
                send();
                Thread Thread2 = new Thread(thread2); 
                //Thread Thread3 = new Thread(thread3); 
               // Thread Thread4 = new Thread(thread4);
                Thread2.Start();
                //Thread3.Start();
               // Thread4.Start();
            }
        }
        public void send()
        {
            send_thread = new Thread(thread1);
            send_thread.Start();
        }

        void thread1()
        {
            send_soc = new UdpClient();
            string str = txtChat.Text;
            send_data = Encoding.UTF8.GetBytes(str);
            send_soc.Send(send_data, send_data.Length, multicast_iep);

            recv_soc = new UdpClient(31002);
            recv_data = recv_soc.Receive(ref recv_ip);
            recv_soc.JoinMulticastGroup(multicast_IP);
            Invoke((MethodInvoker)delegate
            {
                lbxView.Items.Add("서버에서 메세지를 받았습니다.");

            });
            //서버에서 보내는 과정
            ser_send_soc.Send(recv_data, recv_data.Length, recv_ip);

            Cli_recv_data = recv_soc.Receive(ref recv_ip);
            str = Encoding.UTF8.GetString(Cli_recv_data);
            Invoke((MethodInvoker)delegate
            {
                lbxView.Items.Add(str);
                lbxView.Items.Add("서버에서 받아온 채팅 출력");
            });
        }
        void thread2()
        {
            //서버에서 받는 과정

            
        }
        void thread3()
        {
            

        }
        void thread4()
        {
            Cli_recv_soc = new UdpClient(31002);
            //클라이언트에서 받는 과정
            Cli_recv_data = Cli_recv_soc.Receive(ref recv_ip);
            string str = Encoding.UTF8.GetString(Cli_recv_data);
            Invoke((MethodInvoker)delegate
            {
                lbxView.Items.Add(str);
                lbxView.Items.Add("서버에서 받아온 채팅 출력");
            });
        }
        
    }
}
