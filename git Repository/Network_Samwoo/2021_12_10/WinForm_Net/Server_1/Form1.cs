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

namespace Server_1
{
    public partial class Form1 : Form
    {

        string ip = "127.0.0.1";
        int port = 25101;
        Thread listenThread;    //Accept() 블럭
        Thread receiveThread;   //Receive() 작업
        Socket clientSocket;    //연결된 클라이언트 소켓

        public Form1()
        {
            InitializeComponent();
        }
        //listBox에 현재 날짜, 데이터 상태등을 표시
        void Log(string msg)
        {
            listBox1.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="시작")
            {
                button1.Text = "멈춤";
                Log("서버 시작됨");

                //Listen 쓰레드 처리 -> 연결요청 대기상태
                listenThread = new Thread(new ThreadStart(Listen));// Listen메소드 실행
                listenThread.IsBackground = true; // 스레드가 배경 스레드인지 나타내는 함수

                //쓰레드 실행
                listenThread.Start();
            }
            else
            {
                button1.Text = "시작";
                Log("서버 멈춤");
            }
        }
        private void Listen()
        {
            /*IPAddress Class
             IP주소 제공하는 클래스<종단점>
            IPEndPoint(IPAddress,Port)
             */
            IPAddress ipaddress = IPAddress.Parse(ip); //나의 IP

            /*IPEndPoint Class
             IP주소 제공하는 클래스<종단점>
            IPAddress.Any - 사용중인 '모든' 네트워크 인터페이스(랜카드에 할당된 IP주소)를 나타냄
             */
            IPEndPoint endPoint = new IPEndPoint(ipaddress, port); //127.0.0.1 : 25101

            // server 소켓 생성 <- 클라이언트와 연결시켜주는 소켓

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listenSocket.Bind(endPoint); //127.0.0.1 : 25101

            listenSocket.Listen(10);//클라이언트에 의한 연결 요청이 수신될 때까지 기다린다.
            Log("클라이언트 요청 대기중...");
            
            //연결 요청에 대한 수락
            clientSocket = listenSocket.Accept();

            Log("클라이언트 접속됨 - " + clientSocket.LocalEndPoint.ToString());
            //클라이언트와 서버가 연결됨
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();              //Receive 함수 호출
        }
        //수신 처리
        void Receive()
        {
            while (true)
            {
                //연결된 클라이언트가 보낸 데이터 수신
                byte[] receiveBuffer = new byte[1024];
                int length = clientSocket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);

                string msg = Encoding.UTF8.GetString(receiveBuffer);

                Showmsg("상대]" + msg);
                Log("메세지 수신함");
            }
        }
        void Showmsg(string msg)
        {
            richTextBox1.AppendText(msg);
            richTextBox1.AppendText("\r\n");
            this.Activate();
            richTextBox1.Focus();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Trim()!=""&&e.KeyCode==Keys.Enter)
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(textBox1.Text.Trim());
                clientSocket.Send(sendBuffer);
                Log("메세지 전송됨");
                Showmsg("나]" + textBox1.Text);
                textBox1.Text = ""; //초기화
            }
        }
    }
}
