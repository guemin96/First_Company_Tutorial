using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Network_samwoo.Class
{
    class Multicast
    {
        void MultiSend()
        {
            // 1. udp 객체 생성
            UdpClient udp = new UdpClient();
            // 2. multicast 종단점 설정(교환에 수반하는 통신망에서 이용자가 망에 접속되는 점)
            IPEndPoint multicastEP = new IPEndPoint(IPAddress.Parse("229.1.1.229"), 31000);

            for (int i = 1; i <= 60; i++)
            {
                byte[] dgram = Encoding.ASCII.GetBytes("Msg#" + i);
                // multicast 그룹에 데이타그램 전송
                udp.Send(dgram, dgram.Length, multicastEP);
                Console.WriteLine("Msg# " + i);
                Thread.Sleep(1000);
            }
        }
        
        void MultiReceive()
        {
            UdpClient udp = new UdpClient();

            //UDP 로컬 IP/포트에 바인딩
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 31000);
            udp.Client.Bind(localEp);
            IPAddress multicastIP = IPAddress.Parse("229.1.1.229");
            udp.JoinMulticastGroup(multicastIP);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            while (!Console.KeyAvailable)
            {
                //multicast 수신
                byte[] buff = udp.Receive(ref remoteEP);

                string data = Encoding.ASCII.GetString(buff, 0, buff.Length);
                Console.WriteLine(data);
            }
        }



    }
}
