using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public abstract class Battle<PocketMon, BattleManager>
    {
        public abstract void Execute(PocketMon _pocketMon, BattleManager _bm);
    }
    class Attack : Battle<PocketMon, BattleManager>
    {
        public override void Execute(PocketMon _pocketMon, BattleManager _bm)
        {
            int damage = Instance.MyPocketMonList[0].Attack - _pocketMon.Amor;
            if (damage < 0)
                damage = 1;
            _pocketMon.Life = _pocketMon.Life - damage;
            if (_pocketMon.Life<0)
            {
                _pocketMon.Life = 0;
                Console.WriteLine("{0}을 사냥했습니다.", _pocketMon.GetName());
                Console.WriteLine("계속하려면 아무키나 입력하세요.");
                Console.ReadLine();
                _bm.BattleFinish = true;
            }
            else
            {
                Console.WriteLine("{0}을(를) 데미지 {1}으로 공격 {0}의 남은 체력은 {2}", _pocketMon.GetName(), damage, _pocketMon.Life);
            }
        }
    }
    class Inventory : Battle<PocketMon,BattleManager>
    {
        public override void Execute(PocketMon _pocketMon, BattleManager _bm)
        {
            Console.WriteLine("인벤토리 오픈 ");

        }
    }
    class Run : Battle<PocketMon, BattleManager>
    {
        public override void Execute(PocketMon _pocketMon, BattleManager _bm)
        {
            Console.WriteLine("마을로 갑니다..");
            Console.ReadLine();
            Instance.Position = new Wild();
            Instance.Position.Execute();
        }
    }
    class BattleManager
    {
        private bool battleFinish = false;
        public bool BattleFinish
        {
            get { return battleFinish; }
            set { battleFinish = value; }
        }
        private Battle<PocketMon, BattleManager> battle;
        public void SetState(Battle<PocketMon, BattleManager> _battle)
        {
            this.battle = _battle;
        }
        public void Execute(PocketMon _pocketMon)
        {
            battle.Execute(_pocketMon, this);
        }
    }
}
