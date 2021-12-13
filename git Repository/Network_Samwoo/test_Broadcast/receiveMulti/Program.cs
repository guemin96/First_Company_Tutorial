using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];//전송할 데이터를 담을 변수
            UdpClient server = new UdpClient("127.0.0.1", 31000);//서버 IP : 포트
            Console.WriteLine("UDP 서버 접속 성공");
            IPEndPoint cli_ipe = new IPEndPoint(IPAddress.Any, 0); //클라이언트 ip 포트 객체 생성
            data = Encoding.Default.GetBytes("Hello UdpClient");// byte형식으로 인코딩, server로 보내기 위해서는 byte형식으로 보내야하기 때문에
            server.Send(data, data.Length); // 127.0.0.1로 보냄
            for (int i = 0; i < 10; i++)
            {
                data = server.Receive(ref cli_ipe); //서버에서 데이터를 받음
                Console.WriteLine(Encoding.Default.GetString(data));
            }
            server.Close();
        }
    }
}
