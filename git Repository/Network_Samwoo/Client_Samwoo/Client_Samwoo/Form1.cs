using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        TcpListener Server;

        TcpClient client;

        StreamReader Reader;

        StreamWriter Writer;

        NetworkStream stream;

        Thread ReceiveThread;

        bool Connected;

        private delegate void AddTextDelegate(string strText);

        public Client() 
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            String IP = "192.168.2.99"; // 접속 할 서버 아이피를 입력

            int port = 31000; // 포트

            client = new TcpClient();

            client.Connect(IP, port);

            stream = client.GetStream();

            Connected = true;

            textBox1.AppendText("Connected to Server!" + "\r\n");

            Reader = new StreamReader(stream);

            Writer = new StreamWriter(stream);

            ReceiveThread = new Thread(new ThreadStart(Receive));

            ReceiveThread.Start();
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Me : " + textBox2.Text + "\r\n");

            Writer.WriteLine(textBox2.Text); // 보내버리기

            Writer.Flush();

            textBox2.Clear();



        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;

            if (Reader != null) Reader.Close();

            if (Writer != null) Writer.Close();

            if (Server != null) Server.Stop();

            if (client != null) client.Close();

            if (ReceiveThread != null) ReceiveThread.Abort();
        }
        private void Receive() // 서버로 부터 값 받아오기

        {

            AddTextDelegate AddText = new AddTextDelegate(textBox1.AppendText);
            while (Connected)
            {
                Thread.Sleep(1);
                if (stream.CanRead)
                {
                    string tempStr = Reader.ReadLine();
                    if (tempStr.Length > 0)
                    {
                        Invoke(AddText, "You : " + tempStr + "\r\n");
                    }
                }
            }
        }
    }
}
