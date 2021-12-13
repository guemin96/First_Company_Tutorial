using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network_samwoo.Class
{
    class SocketConnect
    {
        public void cre_Server(string txt)
        {
            IPEndPoint ser_ipe = new IPEndPoint(IPAddress.Parse("192.168.2.99"), 31000);// 서버 IP:포트 할당
            UdpClient server = new UdpClient(ser_ipe);// 서버 설정
            Console.WriteLine("UDP 서버 실행");

            byte[] data = new byte[1024];

            IPEndPoint cli_ipe = new IPEndPoint(IPAddress.Any, 0);//클라이언트쪽 IP: 포트 넣을 객체 생성(실제로 생긴건 아님)
            data = server.Receive(ref cli_ipe); //클라이언트쪽으로부터 메세지를 받아옴
            string msg = Encoding.UTF8.GetString(data);// data라는 byte[]타입의 변수를 string 변수로 변환시켜줌
            txt = cli_ipe.ToString() + "에서 보낸 데이터 : " + msg;
            for (int i = 0; i < 10; i++)
            {
                data = Encoding.Default.GetBytes("Send data:[" + i + "]");
                server.Send(data, data.Length, cli_ipe);//클라이언트 쪽으로 데이터를 보냄
            }
            Console.ReadKey();
        }
        //string input_message(UdpClient server)
        //{
        //    byte[] data = new byte[1024];

        //    IPEndPoint cli_ipe = new IPEndPoint(IPAddress.Any, 0);//클라이언트쪽 IP: 포트 넣을 객체 생성(실제로 생긴건 아님)
        //    data = server.Receive(ref cli_ipe); //클라이언트쪽으로부터 메세지를 받아옴
        //    string msg = Encoding.UTF8.GetString(data);// data라는 byte[]타입의 변수를 string 변수로 변환시켜줌
        //    Console.WriteLine("{0}에서 보낸 데이터 : {1}", cli_ipe.ToString(), msg);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        data = Encoding.Default.GetBytes("Send data:[" + i + "]");
        //        server.Send(data, data.Length, cli_ipe);//클라이언트 쪽으로 데이터를 보냄
        //    }
        //    return
        //}
    }
    
}
