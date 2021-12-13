using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class GameManager
    {
        public GameManager()
        {
            Instance.Position = new Village();
        }
        public void Execute()
        {
            Console.Clear();
             
            ShowMenu();

            Console.WriteLine("");
        }

        public void ShowMenu()
        {
            Console.WriteLine(Instance.Position.ToString());
            Console.WriteLine("플레이어의 현재 위치는 {0}입니다.",GetPostion());
            Console.WriteLine("갈 곳을 선택하시오");
            Console.WriteLine("1. 마을 2. 상점 3. 야생");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Instance.Position = new Village();
                    break;
                case "2":
                    Instance.Position = new Shop();
                    break;
                case "3":
                    Instance.Position = new Wild();
                    break;
                default:
                    break;
            }
            while (true)
            {
                Instance.Position.Execute();
            }

        }
        public string GetPostion()
        {
            switch (Instance.Position.ToString())
            {
                case "PocketMon.Village":
                    return "[마을]";
                case "PocketMon.Shop":
                    return "[상점]";
                case "PocketMon.Wild":
                    return "[야생]";
                default:
                    break;
            }
            return null;
        }
    }
}
