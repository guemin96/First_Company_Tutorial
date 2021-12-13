using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;


namespace PocketMon
{
    class GameInstance
    {
        private IGameManager position;
        public IGameManager Position
        {
            set{ position = value;}
            get{ return position;}
        }
        //포켓몬을 여기서 하나씩 생성해준 후에 밑에 List에 하나씩 넣어줄 것임
        private PocketMon myPocketMon;

        public PocketMon MyPocketMon
        {
            set {
                myPocketMon = value;
            }
            get { return myPocketMon; }
        }
        // 내 포켓몬
        private List<PocketMon> myPocketMonList = new List<PocketMon>();
        public List<PocketMon> MyPocketMonList
        {
            set { myPocketMonList = value; }
            get { return myPocketMonList; }
        }
        
        public void Add(PocketMon _pocket)
        {
            myPocketMonList.Add(_pocket);
        }

        public void remove(PocketMon _pocket)
        {
            myPocketMonList.Remove(_pocket);
        }
        //내 아이템 리스트
        private Item myItem;
        public Item MyItem
        {
            set { myItem = value; }
            get { return myItem; }
        }
        private List<Item> myItemList = new List<Item>();
        public List<Item> MyItemList
        {
            set { myItemList = value; }
            get { return myItemList; }
        }

        //야생 포켓몬 리스트
        private PocketMon pocketMon = new PocketMon();
        public PocketMon PocketMon
        {
            set { pocketMon = value;}
            get { return pocketMon; }
        }
        private List<PocketMon> wildpocketMonsList = new List<PocketMon>();
        public List<PocketMon> WildpocketMonsList
        {
            set
            {
                wildpocketMonsList = value;

            }
            get
            {
                return wildpocketMonsList;
            }
        }
        public void WildAdd(PocketMon _pocket)
        {
            wildpocketMonsList.Add(_pocket);
        }


        private static GameInstance instance =null;

        private GameInstance() { }// 생성자 만들어주는 함수
        public static GameInstance Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new GameInstance();
                }
                return instance;
            }
            private set// 게임 진행 설정에 영향을 주는 것도 외부에서 차단시켜야함
            {
                instance = value;
            }
        }



    }
}
