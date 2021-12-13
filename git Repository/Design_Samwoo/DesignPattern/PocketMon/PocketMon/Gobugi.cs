using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class Gobugi : PocketMon
    {
        public Gobugi()
        {
            initPocketMon("Gobugi", "Water", 1, 10, 10, 10);
        }
        public Gobugi(string _name)
        {
            initPocketMon(_name, "Water", 1, 10, 10, 10);
        }
        
    }
}
