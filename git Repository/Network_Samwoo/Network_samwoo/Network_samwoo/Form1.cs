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
using Network_samwoo.Class;

namespace Network_samwoo
{
    public partial class Server : Form
    {
        TcpListener server; // 소켓 서버

        TcpClient client; // 클라이언트

        StreamReader reader;

        StreamWriter writer;

        NetworkStream stream; // 네트워크 스트림 연결

        Thread ReceiveThread;

        bool Connected;

        private delegate void AddTextDelegate(string strText); // 크로스 쓰레드 호출




        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(new ThreadStart(Listen));
            ListenThread.Start();
        }
        void Listen()
        {
            AddTextDelegate AddText = new AddTextDelegate(textBox1.AppendText);

            IPAddress addr = new IPAddress(0); // 서버 ip

            int port = 31000; // 서버 포트

            server = new TcpListener(addr, port);

            server.Start(); // 서버 시작

            Invoke(AddText, "Server Start!" + "\r\n");

            client = server.AcceptTcpClient(); // 클라이언트 연결 수락

            Connected = true;

            Invoke(AddText, "Connected to Client!" + "\r\n");

            stream = client.GetStream(); // 클라이언트 스트림 값 받아오기

            reader = new StreamReader(stream);

            writer = new StreamWriter(stream);

            ReceiveThread = new Thread(new ThreadStart(Receive)); // 값을 받기 위한 쓰레드

            ReceiveThread.Start();

        }
        private void Receive() // 클라이언트에게 받기

        {
            AddTextDelegate AddText = new AddTextDelegate(textBox1.AppendText);
            while (Connected)
            {
                Thread.Sleep(1);
                if (stream.CanRead) // 받아온 데이터가 있다면 출력
                {
                    string tempStr = reader.ReadLine();
                    if (tempStr.Length > 0)
                    {
                        Invoke(AddText, "You : " + tempStr + "\r\n");
                    }
                }
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;

            if (reader != null) reader.Close();

            if (writer != null) writer.Close();

            if (server != null) server.Stop();

            if (client != null) client.Close();

            if (ReceiveThread != null) ReceiveThread.Abort(); // 사용한 객체를 모두 닫아준다

        }

    }
}
