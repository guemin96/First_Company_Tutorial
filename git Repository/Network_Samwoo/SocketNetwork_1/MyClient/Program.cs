using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("클라이언트콘솔창. \n\n\n");

            TcpClient client = new TcpClient();
            //첫 번째 매개변수는 접속할 IP
            //서버가 내 PC에서 돌아가므로 127.0.0.1
            //두 번째 매개변수는 서버에서 설정한 포트번호를 입력해준다.
            client.Connect("127.0.0.1", 9999);

            byte[] buf = Encoding.Default.GetBytes("클라이언트 : 접속합니다.");
            client.GetStream().Write(buf, 0, buf.Length);

            client.Close();
        }
    }
}
