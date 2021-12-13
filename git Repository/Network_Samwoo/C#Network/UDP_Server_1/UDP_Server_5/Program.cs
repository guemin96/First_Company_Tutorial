using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
/*
 * UDP 수신 프로그램 - 멀티캐스트된 데이터를 수신
 */
namespace UDP_Server_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //UdpClient 객체 생성 - 13000 포트
            UdpClient rev = new UdpClient(31003);
            //UDP클라이언트에게 데이터를 송실한 소켓
            UdpClient sender = new UdpClient();
            //IPAddess 객체 생성 - 가입할 멀티캐스트 주소를 저장할 객체 224.0.1.0
            IPAddress multicast_ip = IPAddress.Parse("224.0.1.0");
            //멀티캐스트 가입
            //JoinMulticastGroup(IPAddress 객체) : IPAddress객체가 저장한 IP주소(멀티캐스트주소)
            //로 해당 UDP소켓이 가입하는 기능이 있는 메소드
            rev.JoinMulticastGroup(multicast_ip);
            //IPEndPoint객체 생성 - 0,0 인자로 사용
            IPEndPoint ip = new IPEndPoint(0, 0);
            for (; ; )
            {
                //데이터 수신 - byte[]
                byte[] recv_data = rev.Receive(ref ip);

                string str = Encoding.UTF8.GetString(recv_data);
                //결과출력
                Console.WriteLine("{0}/{1} ID {2}", ip.Address.ToString(), ip.Port, str);

                //채팅다시 보내기
                byte[] send_data = recv_data;
                rev.Send(send_data, send_data.Length, ip);

            }
            //가입한 멀티캐스트 그룹을 탈퇴
            rev.DropMulticastGroup(multicast_ip);
            //UdpClient 객체 연결 종료
            rev.Close();
        }
    }
}
