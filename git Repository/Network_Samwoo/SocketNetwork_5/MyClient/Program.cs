using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientManager clientManager = new ClientManager();
            clientManager
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
