using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Network_samwoo.Class.CastInstance;

namespace Network_samwoo.Class
{
    public class Broadcast
    {
        private static void StartListener()
        {
            UdpClient listener = new UdpClient(Instance.Broadcast_Port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Instance.Broadcast_Port);

            try
            {
                while (true)
                {
                    Console.WriteLine("브로드캐스트를 기다리는 중입니다.");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($"{groupEP}로부터 브로드캐스트를 받았습니다 : ");
                    Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
        public void Send_Broadcast(bool alive_check)
        {
            
            UdpClient udpClient = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, Instance.Broadcast_Port);
            
            //소켓 옵션을 설정하기
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            
            // 버튼 누름으로 이벤트 발생 시키기
            string message = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            udpClient.Send(bytes, bytes.Length, ep);
            udpClient.Close();

            //
            Console.WriteLine("메세지를 브로드캐스트 주소로 보냈습니다.");

            Console.ReadKey();
        }
        
    }
}
