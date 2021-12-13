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
using Client_Samwoo.Class; 
namespace Client_Samwoo
{
    public partial class Client : Form
    {
        UdpClient send_socket;
        UdpClient recv_socket;
        IPAddress multicast_ip = IPAddress.Parse("224.0.1.0");

        IPEndPoint destination_ip = new IPEndPoint(IPAddress.Parse("224.0.1.0"), 31003),
            recv_ip = new IPEndPoint(IPAddress.Any,0);
        bool isConnected;
        string str;
        byte[] send_data;
        byte[] recv_data;
        Thread listen_thread;
        public Client() 
        {
            InitializeComponent();
            isConnected = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            send_socket = new UdpClient();
            string str = "alive check Clear";
            byte[] send_Byte = Encoding.UTF8.GetBytes(str);
            int s = send_socket.Send(send_Byte, send_Byte.Length, destination_ip);
            send_socket.JoinMulticastGroup(multicast_ip);
            if (s==0)
            {
                lbxView.Items.Add("연결에 실패했습니다.");
            }
            else
            {
                isConnected = true;
                lbxView.Items.Add("연결에 성공했습니다.");
            }
            listen_thread = new Thread(do_receive);
            listen_thread.Start();

        }
        void do_receive()
        {
            while (isConnected)
            {
                while (true)
                {
                    byte[] recv_data = new byte[1024];
                    recv_socket = new UdpClient(31001);
                    recv_data = recv_socket.Receive(ref recv_ip);
                    str = Encoding.UTF8.GetString(recv_data);
                    break;
                }
                Invoke((MethodInvoker)delegate
                {
                    lbxView.Items.Add(str);
                }
                );
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            send_socket.Close();
            recv_socket.Close();
            Close();
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            send_data = Encoding.UTF8.GetBytes(txtChat.Text);
            send_socket.Send(send_data, send_data.Length, destination_ip);

        }
    }
}
