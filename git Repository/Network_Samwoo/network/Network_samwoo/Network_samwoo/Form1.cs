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
using Network_samwoo.Class;

namespace Network_samwoo
{
    public partial class Server : Form
    {
        UdpClient send_socket; // 서버 소켓
        UdpClient recv_socket;
        bool isConnected; // 서버와 클라이언트가 연결되었는지 판단
        //IPEndPoint객체 생성
        IPEndPoint multi_ip = new IPEndPoint(IPAddress.Parse("224.0.1.0"), 31003),
              recv_ip = new IPEndPoint(IPAddress.Any,0);

        

        //byte[] bytes = new byte[1024];
        string str; //채팅서버로 글자 데이터를 읽고 불러오는데 쓰이는 변수
        byte[] send_data;
        byte[] recv_data;
        int clientCount = 0;
        public Server()
        {
            InitializeComponent();

        }
       

        private void btnConnect_Click(object sender, EventArgs e)
        {
            recv_socket = new UdpClient(31003);
            send_socket = new UdpClient();
            IPAddress multicast_ip = IPAddress.Parse("224.0.1.0");
            recv_socket.JoinMulticastGroup(multicast_ip);                                                                                                                                                                                                                           
            lbxView.Items.Add("서버구축을 완료하였습니다.");
            isConnected = true;
            Thread listen_thread = new Thread(do_receive);
            listen_thread.Start();

        }
        void do_receive()
        {
            while (isConnected)
            {
                while (true)
                {
                    recv_data = new byte[1024];
                    recv_data = recv_socket.Receive(ref recv_ip);
                    str = Encoding.UTF8.GetString(recv_data);
                    break;
                }
                Invoke((MethodInvoker)delegate 
                {
                    lbxView.Items.Add(str);
                    recv_socket.Send(recv_data, recv_data.Length, recv_ip);

                }
                );
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            recv_socket.Close();
            send_socket.Close();
            Close();
        }
    }
}
