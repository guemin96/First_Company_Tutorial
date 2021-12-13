using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("서버콘솔창. \n");

            TcpListener server = new TcpListener(IPAddress.Any, 10002);

            server.Start();

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("클라이언트가 접속하였습니다.");

            while (true)
            {
                byte[] byteData = new byte[1024];
                client.GetStream().Read(byteData, 0, byteData.Length);

                string strData = Encoding.Default.GetString(byteData);

                int endPoint = strData.IndexOf('\0');
                string parsedMessage = strData.Substring(0, endPoint + 1);

                Console.WriteLine(parsedMessage);
            }
        }
    }
    class MyContinuousClient
    {
        TcpClient client = null;
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("==========클라이언트===========");
                Console.WriteLine("1. 서버연결");
                Console.WriteLine("2. Message 보내기");
                Console.WriteLine("===============================");

                string key = Console.ReadLine();
                int order = 0;
                // 입력받은 key의 값을 int.TryParse를 사용해 int형으로 형변환해줍니다.
                // 형변환에 성공하면 order에 변환된 값이 저장됩니다.
                // 형변황에 실패하면 false를 리턴합니다.

                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case 1:
                        {
                            if (client != null)
                            {
                                Console.WriteLine("이미 연결되어있습니다.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Connect();
                            }
                            break;
                        }
                        case 2:
                        {
                            if (client == null)
                            {
                                Console.WriteLine("먼저 서버와 연결해주세요");
                                Console.ReadKey();
                            }
                            else
                            {
                                SendMessage();
                            }
                            break;

                        }
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        private void SendMessage()
        {
            Console.WriteLine("보낼 message를 입력해주세요.");
            string message = Console.ReadLine();
            byte[] byteData = new byte[message.Length];
            byteData = Encoding.Default.GetBytes(message);

            client.GetStream().Write(byteData, 0, byteData.Length);
            Console.WriteLine("전송성공");
            Console.ReadKey();
        }
        private void Connect()
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 9999);
            Console.WriteLine("서버연결 성공 이제 Message를 입력해주세요.");
            Console.ReadKey();
        }
    }
}
