using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class PlayerManager
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void Execute()
        {
            FirstPocketMon();
        }

        private void FirstPocketMon()
        {
            Console.WriteLine("함께 할 포켓몬을 고르시오 (1.피카츄 2.파이리 3.꼬부기 4.이상해씨 )");
            string inputNum = Console.ReadLine();
            switch (inputNum)
            {
                case "1": inputNum = "1";break;
                case "2": inputNum = "2";break;
                case "3": inputNum = "3";break;
                case "4": inputNum = "4";break;
            }

            Console.WriteLine("포켓몬의 별명을 입력해주세요");
            string inputName = Console.ReadLine();

            MyPocketMon myPocketMon = new MyPocketMon();
            // 내 포켓몬 생성 후 포켓몬 리스트에 저장
            Instance.Add(myPocketMon.Create(inputNum, inputName));
            Console.WriteLine("능력치 확인");
            Instance.MyPocketMonList.LastOrDefault().Attack=20;
            Instance.MyPocketMonList.LastOrDefault().Life=100;

        }

        
    }
}
