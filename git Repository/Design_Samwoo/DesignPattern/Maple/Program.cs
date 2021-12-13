using System;

namespace Maple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("게임시작(0을 누르시오)");
            string input = Console.ReadLine();
            if (input =="0")
            {
                CharactorManager cm = new CharactorManager();
                GameManager gm = new GameManager();

                cm.Execute();
                gm.Execute();
            }
        }
    }
}
