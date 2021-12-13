using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public abstract class IWildMenu
    {
        public abstract void Execute();
    }
    class FindMonster : IWildMenu
    {
        private Battle<PocketMon, BattleManager> battle;
        public override void Execute()
        {
            WildPocketManager pm = new WildPocketManager();
            BattleManager bm = new BattleManager();
            PocketMon pocketMon = new PocketMon();

            pocketMon = pm.RespawnMonster();

            int a = 0;
            Random random = new Random();
            a= random.Next(0,3);

            wildPocketMon();

            Console.WriteLine("야생 숲입니다.");

            Console.WriteLine(Instance.WildpocketMonsList[a].ToString());

            Console.WriteLine("{0}을 발견했습니다.",pocketMon.GetName());
            while (bm.BattleFinish !=true)
            {
                ShowBattleMenu();
                bm.SetState(battle);
                bm.Execute(pocketMon);
            }
            string input = Console.ReadLine();

            
        }
        private void ShowBattleMenu()
        {
            Console.WriteLine("1. 공격 2. 인벤토리 3. 마을로 돌아가기");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    battle = new Attack();
                    break;
                case "2":
                    battle = new Inventory();
                    break;
                case "3":
                    battle = new Run();
                    break;
            }
        }

        private void wildPocketMon()
        {
            Pikachu pikachu = new Pikachu();
            Pairi pairi = new Pairi();
            Gobugi gobugi = new Gobugi();
            Esanghesi esanghesi = new Esanghesi();
            Instance.WildpocketMonsList.Add(pikachu);
            Instance.WildpocketMonsList.Add(pairi);
            Instance.WildpocketMonsList.Add(gobugi);
            Instance.WildpocketMonsList.Add(esanghesi);
        }
    }

}
