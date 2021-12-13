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
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 9999));
            listener.Start();
            Console.WriteLine("서버를 시작합니다. 클라이언트의 접속을 기다립니다.");

            // 연결을 요청한 client의 객체를 acceptClient에 저장
            TcpClient acceptClient = listener.AcceptTcpClient();
            Console.WriteLine("클라이언트 접속성공.");

            // ClientData의 객체를 생성해주고 연결된 클라이언트를 ClientData의 멤버로 설정해준다.
            ClientData clientData = new ClientData(acceptClient);

            //BeginRead를 통해 비동기로 읽는다.(읽을 데이터가 올때까지 대기하지 않고 바로 아랫줄의 while문으로 이동한다.)
            clientData.client.GetStream().BeginRead(clientData.readByteData, 0, clientData.readByteData.Length, new AsyncCallback(DataReceived), clientData);

            //데이터를 읽든 못읽든 일단 바로 해당로직이 실행된다(비동기서버)
            while (true)
            {
                Console.WriteLine("서버 구동중");
                Thread.Sleep(1000);
            
                    
            }
        }
        //AsyncCallback의 매개변수에 콜백메서드를 등록해주면 클라이언트가 메시지를 보내서 서버가 해당 메시지를 읽게 됐을 때 콜백메서드가 실행됩니다.
        
        private void DataReceived(IAsyncResult ar)
        {
            // 콜백 메서드입니다.(피호출자가 호출자의 해당 메서드를 실행시켜줍니다.)
            // 즉 데이터를 읽었을때 실행됩니다.
            
            // 콜백으로 받아온 Data를 ClientData로 형변환 해줍니다.

            ClientData callbackClient = ar.AsyncState as ClientData;

            // 실제로 넘어온 크기를 받아옵니다
            int bytesRead = callbackClient.client.GetStream().EndRead(ar);

            // 문자열로 넘어온 데이터를 파싱해서 출력해줍니다.
            string readString = Encoding.Default.GetString(callbackClient.readByteData, 0, bytesRead);

            Console.WriteLine(readString);

            // 비동기서버에서 가장 중요한 핵심입니다.
            // 비동기서버는 while문을 돌리지 않고 콜백메서드에서 다시 읽으라고 비동기명령을 내립니다.
            callbackClient.client.GetStream().BeginRead(callbackClient.readByteData, 0, callbackClient.readByteData.Length, new AsyncCallback(DataReceived), callbackClient);
        }
    }
    class ClientData
    {
        // 연결이 확인된 클라이언트를 넣어줄 클래스
        // readByteData는 stream데이터를 읽어올 객체입니다.
        public TcpClient client { get; set; }
        public byte[] readByteData { get; set; }

        public ClientData(TcpClient client)
        {
            this.client = client;
            this.readByteData = new byte[1024];
        }
    }
}
