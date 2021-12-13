using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public abstract class Item
    {
        public int num;
    }

    class MonsterBall : Item
    {
        public MonsterBall()
        {
            //야생에서 싸울때 잡는 형식으로 만들기
        }

    }
    class Potion : Item
    {
        public Potion()
        {
            Instance.MyPocketMon.Life = +10;
        }

    }


}
