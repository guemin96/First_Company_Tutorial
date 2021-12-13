using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client_2
{
    public partial class Form1 : Form
    {
        Socket socket; // 소켓
        Thread receiveThread; // 대화 수신용

        public Form1()
        {
            InitializeComponent();
        }
        void Log(string msg)
        {
            listBox1.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            Log("클라이언트 로드됨!!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipaddress = IPAddress.Parse(textBox1.Text);
            IPEndPoint endPoint = new IPEndPoint(ipaddress, int.Parse(textBox2.Text));

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Log("서버에 연결 시도중");
            socket.Connect(endPoint);// 연결시도 connect;
            Log("서버에 접속됨");
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        void Receive()
        {
            while (true)
            {
                //연결된 클라이언트가 보낸 데이터 수신
                byte[] receiveBuffer = new byte[1024];
                int length = socket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
                string msg = Encoding.UTF8.GetString(receiveBuffer, 0, length);
                ShowMsg("상대]" + msg);
            }
        }
        void ShowMsg(string msg)
        {
            richTextBox1.AppendText(msg);
            richTextBox1.AppendText("\r\n");
            this.Activate();
            richTextBox1.Focus();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.Trim()!=""&& e.KeyCode==Keys.Enter)
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(textBox3.Text);
                socket.Send(sendBuffer);
                Log("메세지 전송됨");
                ShowMsg("나]" + textBox3.Text);
                textBox3.Text = "";
            }
        }
    }
}
