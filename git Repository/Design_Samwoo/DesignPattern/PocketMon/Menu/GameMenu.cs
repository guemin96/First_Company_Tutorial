using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public abstract class IGameManager // 추상 클래스로 하위 클래스들에게 Execute라는 함수를 오버라이딩하게 만들어줌
    {
        public abstract void Execute();
    }
    class Village : IGameManager
    {
        public override void Execute()
        {
            Console.WriteLine("현재 위치는 마을입니다.");
            Console.WriteLine("갈 곳을 선택하시오.(1. 마을 2.상점 3.야생)");
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
        }
    }
    class Shop : IGameManager
    {
        public override void Execute()
        {
            Console.WriteLine("현재 위치는 상점입니다.");
            Console.WriteLine("1. 구매 2.판매 3. 이동 4. 아이템 확인");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1"://구매
                case "2"://판매
                case "3"://이동
                    Instance.Position = new Village();
                    break;
                case "4"://아이템 확인

                default:
                    break;
            }
        }
    }
    class Wild : IGameManager
    {
        private IWildMenu menu;
        public Wild()
        {
            
        }
        public override void Execute()
        {
            Console.WriteLine("플레이어의 현재 위치는 {0}입니다.", Instance.Position);
            Console.WriteLine("몬스터를 발견하셨습니다. 싸우시겠습니까?(1. 싸우기 2. 마을로 돌아가기)");
            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    menu = new FindMonster();
                    menu.Execute();
                    break;
                case "2":
                    Instance.Position = new Village();
                    Instance.Position.Execute();
                    return;
                default:
                    break;
            }
        }
    }


}
