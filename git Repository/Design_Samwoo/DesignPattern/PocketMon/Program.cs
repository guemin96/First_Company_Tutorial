using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerManager pm = new PlayerManager();
            GameManager gm = new GameManager();

            Console.WriteLine("게임을 시작하시겠습니까? 0번을 누르면 시작하겠습니다.");
            string input = Console.ReadLine();
            Console.Clear();

            if (input=="0")
            {
                pm.Execute();
                gm.Execute();
                
            }

        }
    }
}
