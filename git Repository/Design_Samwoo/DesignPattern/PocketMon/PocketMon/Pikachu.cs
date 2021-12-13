using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class Pikachu : PocketMon
    {
        public Pikachu() {
            initPocketMon("Pikachu", "Electronic", 1, 10, 10, 10);
        }
        public Pikachu(string _name)// _name 별명
        {
            initPocketMon(_name, "Electronic", 1, 10, 10, 10);
        }
    }
}
