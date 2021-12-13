using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChattingClient.Class;
namespace ChattingClient.Class
{
    class ConsoleClient
    {
        TcpClient client = null;
        Thread receiveMessageThread = null;
        ConcurrentBag<string> sendMessageListToView = null;
        ConcurrentBag<string> receiveMessageListToView = null;
        private string name = null;

        // 서버를 구동합니다.
        public void Run()
        {
            sendMessageListToView = new ConcurrentBag<string>();
            receiveMessageListToView = new ConcurrentBag<string>();

            receiveMessageThread = new Thread(receiveMessage);
            while (true)
            {
                Console.WriteLine("==========클라이언트==========");
                Console.WriteLine("1.서버연결");
                Console.WriteLine("2.Message 보내기");
                Console.WriteLine("3.보낸 Message확인");
                Console.WriteLine("4.받은 Message확인");
                Console.WriteLine("0.종료");
                Console.WriteLine("==============================");

                string key = Console.ReadLine();
                int order = 0;


                if (int.TryParse(key, out order))
                {
                    switch (order)
                    {
                        case StaticDefine.CONNECT:
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
                        case StaticDefine.SEND_MESSAGE:
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
                        case StaticDefine.SEND_MSG_VIEW:
                            {
                                SendMessageView();
                                break;
                            }
                        case StaticDefine.RECEIVE_MSG_VIEW:
                            {
                                ReceiveMessageVIew();
                                break;
                            }

                        case StaticDefine.EXIT:
                            {
                                if (client != null)
                                {
                                    client.Close();
                                }
                                receiveMessageThread.Abort();
                                return;
                            }
                    }
                }

                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Console.ReadKey();
                }
                Console.Clear();
                Thread.Sleep(50);
            }
        }

        // 사용자로부터 받은 메시지를 확인하는 기능입니다.
        private void ReceiveMessageVIew()
        {
            if (receiveMessageListToView.Count == 0)
            {
                Console.WriteLine("받은 메시지가 없습니다.");
                Console.ReadKey();
                return;
            }

            foreach (var item in receiveMessageListToView)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        // 사용자에게 보낸 메시지를 확인하는 기능입니다.
        private void SendMessageView()
        {
            if (sendMessageListToView.Count == 0)
            {
                Console.WriteLine("보낸 메시지가 없습니다.");
                Console.ReadKey();
                return;
            }
            foreach (var item in sendMessageListToView)
            {
                Console.WriteLine(item);

            }
            Console.ReadKey();
        }

        // 서버에서 보낸 메시지를 읽어주는 메서드이며 스레드를 생성해 돌려줍니다. 
        private void receiveMessage()
        {
            string receiveMessage = "";
            List<string> receiveMessageList = new List<string>();
            while (true)
            {
                byte[] receiveByte = new byte[1024];
                client.GetStream().Read(receiveByte, 0, receiveByte.Length);

                receiveMessage = Encoding.Default.GetString(receiveByte);

                string[] receiveMessageArray = receiveMessage.Split('>');
                foreach (var item in receiveMessageArray)
                {
                    if (!item.Contains('<'))
                        continue;
                    // 관리자<TEST>는 서버에서 보내는 하트비트 메시지이니 무시해줍니다. 
                    if (item.Contains("관리자<TEST"))
                        continue;
                    receiveMessageList.Add(item);

                }
                ParsingReceiveMessage(receiveMessageList);

                Thread.Sleep(500);
            }
        }

        // 서버가 보낸 메시지를 역캡슐화하는 과정입니다.
        private void ParsingReceiveMessage(List<string> messageList)
        {
            foreach (var item in messageList)
            {
                string sender = "";
                string message = "";

                if (item.Contains('<'))
                {
                    string[] splitedMsg = item.Split('<');

                    sender = splitedMsg[0];
                    message = splitedMsg[1];

                    if (sender == "관리자")
                    {
                        string userList = "";
                        string[] splitedUser = message.Split('$');
                        foreach (var el in splitedUser)
                        {
                            if (string.IsNullOrEmpty(el))
                                continue;
                            userList += el + " ";
                        }
                        Console.WriteLine(string.Format("[현재 접속인원] {0}", userList));
                        messageList.Clear();
                        return;
                    }

                    Console.WriteLine(string.Format("[메시지가 도착하였습니다] {0} : {1}", sender, message));
                    receiveMessageListToView.Add(string.Format("[{0}] Sender : {1}, Message : {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sender, message));
                }
            }
            messageList.Clear();
        }

        // 사용자가 메시지를 보내는 기능입니다.
        private void SendMessage()
        {
            string getUserList = string.Format("{0}<GiveMeUserList>", name);
            byte[] getUserByte = Encoding.Default.GetBytes(getUserList);
            client.GetStream().Write(getUserByte, 0, getUserByte.Length);

            Console.WriteLine("수신자를 입력해주세요");
            string receiver = Console.ReadLine();

            Console.WriteLine("보낼 message를 입력해주세요");
            string message = Console.ReadLine();

            if (string.IsNullOrEmpty(receiver) || string.IsNullOrEmpty(message))
            {
                Console.WriteLine("수신자와 보낼 message를 확인해주세요");
                Console.ReadKey();
                return;
            }

            string parsedMessage = string.Format("{0}<{1}>", receiver, message);

            byte[] byteData = new byte[1024];
            byteData = Encoding.Default.GetBytes(parsedMessage);

            client.GetStream().Write(byteData, 0, byteData.Length);
            sendMessageListToView.Add(string.Format("[{0}] Receiver : {1}, Message : {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), receiver, message));
            Console.WriteLine("전송성공");
            Console.ReadKey();
        }

        // 서버에 접속하는 메서드입니다.
        private void Connect()
        {
            Console.WriteLine("이름을 입력해주세요");

            name = Console.ReadLine();

            string parsedName = "%^&" + name;
            if (parsedName == "%^&")
            {
                Console.WriteLine("제대로된 이름을 입력해주세요");
                Console.ReadKey();
                return;
            }

            client = new TcpClient();
            // 하나의 PC에서 사용하므로 루프백IP를 사용하였습니다.
            // 여러개의 PC에서 사용하려면 서버PC의 실제 IP를 입력해주셔야됩니다.
            client.Connect("127.0.0.1", 31000);

            byte[] byteData = new byte[1024];
            byteData = Encoding.Default.GetBytes(parsedName);
            client.GetStream().Write(byteData, 0, byteData.Length);

            // 서버에 접속하고 서버의 메시지를 받아주는 스레드를 돌려줍니다.
            receiveMessageThread.Start();

            Console.WriteLine("서버연결 성공 이제 Message를 보낼 수 있습니다.");
            Console.ReadKey();
        }
    }
}
