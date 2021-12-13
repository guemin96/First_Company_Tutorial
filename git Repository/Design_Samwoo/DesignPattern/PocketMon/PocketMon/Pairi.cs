using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class Pairi : PocketMon
    {
        public Pairi()
        {
            initPocketMon("Pairi", "Fire", 1, 10, 10, 10);

        }
        public Pairi(string _name)
        {
            initPocketMon(_name, "Fire", 1, 10, 10, 10);
        }
        

    }
}
