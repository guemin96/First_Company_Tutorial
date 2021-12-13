using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyServer a = new MyServer();
        }
    }
    class MyServer
    {
        public MyServer()
        {
            AsyncServerStart();
        }
        private void AsyncServerStart()
        {
            
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 31000));
            listener.Start();
            Console.WriteLine("서버를 시작합니다.");

            //클라이언트의 접속을 확인하면 스레드풀에서 해당클라이언트의 메시지를 일도록 대기시키고
            //while문을 통해 다시 클라이언트의 접속을 기다립니다.
            while (true)
            {
                TcpClient acceptClient = listener.AcceptTcpClient();
                ClientData clientData = new ClientData(acceptClient);
                clientData.client.GetStream().BeginRead(clientData.readByteData, 0, clientData.readByteData.Length, new AsyncCallback(DataReceived), clientData);
            }
        }
        private void DataReceived(IAsyncResult ar)
        {
            ClientData callbackClient = ar.AsyncState as ClientData;
            int bytesRead = callbackClient.client.GetStream().EndRead(ar);
            string readString = Encoding.Default.GetString(callbackClient.readByteData, 0, bytesRead);
            Console.WriteLine("{0}번 사용자 : {1}", callbackClient.clientNumber, readString);
            callbackClient.client.GetStream().BeginRead(callbackClient.readByteData, 0, callbackClient.readByteData.Length, new AsyncCallback(DataReceived), callbackClient);
        }
    }
    class ClientData
    {
        //연결이 확인된 클라이언트를 넣어줄 클래스입니다.
        //readByteData는 stream데이터를 읽어올 객체입니다.
        public TcpClient client { get; set; }
        public byte[] readByteData { get; set; }
        public int clientNumber;
        public ClientData(TcpClient client)
        {
            this.client = client;
            this.readByteData = new byte[1024];

            //아래 부분이 1:1비동기서버에서 추가된 부분입니다.
            //127.0.0.1:9999에서 포트번호 직전 마지막번호를 클라이언트 번호로 지정해줍니다.
            string clientEndPoint = client.Client.LocalEndPoint.ToString();
            char[] point = { '.', ':' };
            string[] splitedData = clientEndPoint.Split(point);
            this.clientNumber = int.Parse(splitedData[3]);
            Console.WriteLine("{0}번 사용자 접속성공", clientNumber);

        }
    }
}
