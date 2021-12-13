using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMon
{
    class WildPocketManager
    {
        List<PocketMon> pocketMons = new List<PocketMon>();

        public PocketMon RespawnMonster()
        {
            Random rand = new Random();
            int a = rand.Next(0, 3);

            return pocketMons[a];
        }
        public WildPocketManager()
        {
            pocketMons.Add(new Pikachu());
            pocketMons.Add(new Pairi());
            pocketMons.Add(new Gobugi());
            pocketMons.Add(new Esanghesi());
        }

    }
}
