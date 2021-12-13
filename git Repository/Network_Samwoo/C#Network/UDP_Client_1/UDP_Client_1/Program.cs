using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace UDP_Client_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //UdpClient 객체 생성 - 데이터를 먼저 보내는 송신자측은 포트번호 임시발급
            UdpClient client = new UdpClient();
            //서버의 IP/PORT를 저장
            IPEndPoint des_ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31000);
            //데이터 송신
            string data = "Hello UDP!";
            //입력한 문자열을 byte배열로 변경
            byte[] byte_data = Encoding.UTF8.GetBytes(data);
            //데이터를 수신받는 프로그램이 없더라도 비연결지향 프로토콜인 UDP는
            //예외가 발생하지 않음
            client.Send(byte_data, byte_data.Length, des_ip);
            //UdpClient 객체 종료
            client.Close();
        }
    }
}
