using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainServer a = new MainServer();
            a.ConSoleVIew();
            
        }
    }
    public class MainServer
    {
        ClientManager _clientManager = null;
        ConcurrentBag<string> chattingLog = null;
        ConcurrentBag<string> AccessLog = null;
        Thread conntectCheckThread = null;

        public MainServer()
        {
            // 생성자에서는 클라이언트매니저의 객체를 생성,
            // 채팅로그와 접근로그를 담을 컬렉션 생성
            // 서버 스레드 및 하트비트 스레드 시작

            _clientManager = new ClientManager();
            chattingLog = new ConcurrentBag<string>();
            AccessLog = new ConcurrentBag<string>();
            _clientManager.EventHandler += ClientEvent;
            _clientManager.messageParsingAction += MessageParsing;
            Task serverStart = Task.Run(() =>
            {
                ServerRun();
            });

            conntectCheckThread = new Thread(ConnectCheckLoop);
            conntectCheckThread.Start();
        }
        private void ConnectCheckLoop()
        {
            while (true)
            {
                foreach (var item in ClientManager.clientDic)
                {
                    try
                    {
                        string sendStringData = "관리자<TEST>";
                        byte[] sendByteData = new byte[sendStringData.Length];
                        sendByteData = Encoding.Default.GetBytes(sendStringData);

                        item.Value.tcpClient.GetStream().Write(sendByteData, 0, sendByteData.Length);
                    }
                    catch (Exception e)
                    {
                        RemoveClient(item.Value);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        //클라이언트의 접속종료가 감지됏을때 static 예약어로 저장된 clientDic에서 해당클라이언트를 제거하고, 로그를 남깁니다.
        private void RemoveClient(ClientData targetClient)
        {
            ClientData result = null;
            ClientManager.clientDic.TryRemove(targetClient.clientNumber, out result);
            string leaveLog = string.Format("[{0}] {1} Leave Server", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), result.clientName);
            AccessLog.Add(leaveLog);
        }
        // 클라이언트에게 메시지를 보내는 첫번째 과정입니다.
        private void MessageParsing(string sender, string message)
        {
            List<string> msgList = new List<string>();

            string[] msgArray = message.Split('>');
            foreach (var item in msgArray)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                msgList.Add(item);
            }
            SendMsgToclient(msgList, sender);
        }
        //클라이언트에게 메세지를 보내는 두번째 과정입니다.
        private void SendMsgToclient(List<string> msgList, string sender)
        {
            string LogMessage = "";
            string parsedMessage = "";
            string receiver = "";

            int senderNumber = -1;
            int receiverNumber = -1;

            foreach (var item in msgList)
            {
                string[] splitedMsg = item.Split('<');
                receiver = splitedMsg[0];
                parsedMessage = string.Format("{0}<{1}>", sender, splitedMsg[1]);
                senderNumber = GetClientNumber(sender);
                receiverNumber = GetClientNumber(receiver);

                if (senderNumber ==-1 || receiverNumber ==-1)
                {
                    return;
                }
                if (parsedMessage.Contains("<GiveMeUserList>"))
                {
                    string userListStringData = "관리자<";
                    foreach (var el in ClientManager.clientDic)
                    {
                        userListStringData += string.Format("${0}", el.Value.clientName);
                    }
                    userListStringData += ">";
                    byte[] userListByteData = Encoding.Default.GetBytes(userListStringData);
                    ClientManager.clientDic[receiverNumber].tcpClient.GetStream().Write(userListByteData, 0, userListByteData.Length);
                    return;
                }

                LogMessage = string.Format(@"[{0}] [{1}] -> [{2}] ,{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),sender,receiver,splitedMsg[1]);
                ClientEvent(LogMessage, StaticDefine.ADD_CHATTING_LOG);
                byte[] sendByteData = Encoding.Default.GetBytes(parsedMessage);
                ClientManager.clientDic[receiverNumber].tcpClient.GetStream().Write(sendByteData, 0, sendByteData.Length);
            }
        }
        //클라이언트의 이름을 통해 ClientNumber를 얻는 메서드입니다.
        //ClientDictionary는 ClientNumber를 키로 사용하고 있어서
        //클라이언트의 번호를 통해 클라이언트 객체를 반환받을 수 있습니다.
        private int GetClientNumber(string targetClientName)
        {
            foreach (var item in ClientManager.clientDic)
            {
                if (item.Value.clientName == targetClientName)
                {
                    return item.Value.clientNumber;
                }
            }
            return -1;
        }
        // 접근로그와 채팅로그를 저장하는 메서드입니다.
        // StaticDefine은 제가 만든 클래스로 정적변수에 번호를 지정해놨습니다.
        private void ClientEvent(string message, int key)
        {
            switch (key)
            {
                case StaticDefine.ADD_ACCESS_LOG:
                    {
                        AccessLog.Add(message);
                        break;
                    }
                case StaticDefine.ADD_CHATTING_LOG:
                    {
                        chattingLog.Add(message);
                        break;
                    }
            }
        }
        //서버돌리는 과정
        private void ServerRun()
        {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 10002));
            listener.Start();
            
            while (true)
            {   Task<TcpClient> acceptTask = listener.AcceptTcpClientAsync(); 
                acceptTask.Wait(); 
                TcpClient newClient = acceptTask.Result; 
                _clientManager.AddClient(newClient); 
            }

        }
        // 기본적으로 서버가 돌아가는 콘솔 로직입니다.
        public void ConSoleVIew() 
        { while (true) 
            { Console.WriteLine("=============서버============="); 
                Console.WriteLine("1.현재접속인원확인"); 
                Console.WriteLine("2.접속기록확인"); 
                Console.WriteLine("3.채팅로그확인"); 
                Console.WriteLine("0.종료"); 
                Console.WriteLine("=============================="); 
                string key = Console.ReadLine(); 
                int order = 0; 
                if (int.TryParse(key, out order)) 
                { 
                    switch (order) 
                    { 
                        case StaticDefine.SHOW_CURRENT_CLIENT: 
                            { 
                                ShowCurrentClient(); 
                                break;
                            } 
                        case StaticDefine.SHOW_ACCESS_LOG: 
                            { 
                                ShowAccessLog();
                                break;
                            } 
                        case StaticDefine.SHOW_CHATTING_LOG: 
                            { 
                                ShowChattingLog();
                                break;
                            } 
                        case StaticDefine.EXIT: 
                            { 
                                conntectCheckThread.Abort(); 
                                return;
                            } 
                        default: 
                            { 
                                Console.WriteLine("잘못 입력하셨습니다."); 
                                Console.ReadKey(); 
                                break; 
                            } 
                    } 
                } 
                else { 
                    Console.WriteLine("잘못 입력하셨습니다."); 
                    Console.ReadKey();
                } 
                Console.Clear(); 
                Thread.Sleep(50); 
            } 
        }
        private void ShowChattingLog()
        {
            if (chattingLog.Count == 0)
            {
                Console.WriteLine("채팅기록이 없습니다.");
                Console.ReadKey();
                return;
            }
            foreach (var item in chattingLog)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        //접속 로그 확인
        private void ShowAccessLog()
        {
            if (AccessLog.Count == 0)
            {
                Console.WriteLine("접속기록이 없습니다.");
                Console.ReadKey();
                return;
            }
            foreach (var item in AccessLog)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        //현재 접속 유저확인
        private void ShowCurrentClient()
        {
            if (ClientManager.clientDic.Count ==0)
            {
                Console.WriteLine("접속자가 없습니다.");
                Console.ReadKey();
                return;
            }
            foreach (var item in ClientManager.clientDic)
            {
                Console.WriteLine(item.Value.clientName);
            }
            Console.ReadKey();
        }
    }
    class ClientManager
    {
        public static ConcurrentDictionary<int, ClientData> clientDic = new ConcurrentDictionary<int, ClientData>();
        public event Action<string, string> messageParsingAction = null;
        public event Action<string, int> EventHandler = null;

        public void AddClient(TcpClient newClient)
        {
            ClientData currentClient = new ClientData(newClient);

            try
            {
                currentClient.tcpClient.GetStream().BeginRead(currentClient.readBuffer, 0, currentClient.readBuffer.Length, new AsyncCallback(DataReceived), currentClient);
                clientDic.TryAdd(currentClient.clientNumber, currentClient);
            }
            catch (Exception e)
            {

            }
        }
        private void DataReceived(IAsyncResult ar)
        {
            ClientData client = ar.AsyncState as ClientData;

            try
            {
                int byteLength = client.tcpClient.GetStream().EndRead(ar);
                string strData = Encoding.Default.GetString(client.readBuffer, 0, byteLength);
                client.tcpClient.GetStream().BeginRead(client.readBuffer, 0, client.readBuffer.Length, new AsyncCallback(DataReceived), client);

                if (string.IsNullOrEmpty(client.clientName))
                {
                    if (EventHandler != null)
                    {
                        if (CheckID(strData))
                        {
                            string userName = strData.Substring(3);
                            client.clientName = userName;
                            string accessLog = string.Format("[{0}] {1} Access Server", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), client.clientName);
                            EventHandler.Invoke(accessLog, StaticDefine.ADD_ACCESS_LOG);
                            return;
                        }
                    }
                }
                if (messageParsingAction != null)
                {
                    messageParsingAction.BeginInvoke(client.clientName, strData, null, null);
                }
            }
            catch (Exception e)
            {

            }
        }
        private bool CheckID(string ID)
        {
            if (ID.Contains("&^&"))
                return true;
            return false;
        }
    }
    class ClientData
    {
        public TcpClient tcpClient { get; set; }
        public Byte[] readBuffer { get; set; }
        public StringBuilder currentMsg { get; set; }
        public string clientName { get; set; }
        public int clientNumber { get; set; }

        public ClientData(TcpClient tcpClient)
        {
            currentMsg = new StringBuilder();
            readBuffer = new byte[1024];

            this.tcpClient = tcpClient;
            char[] splitDivision = new char[2];
            splitDivision[0] = '.';
            splitDivision[1] = ':';

            string[] temp = null;
            temp = tcpClient.Client.LocalEndPoint.ToString().Split(splitDivision);
            this.clientNumber = int.Parse(temp[3]);
        }
    }
    class StaticDefine
    {
        public const int SHOW_CURRENT_CLIENT = 1;
        public const int SHOW_ACCESS_LOG = 2;
        public const int SHOW_CHATTING_LOG = 3;
        public const int ADD_ACCESS_LOG = 5;
        public const int ADD_CHATTING_LOG = 6;
        public const int EXIT = 0;
    }

}
