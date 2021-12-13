using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    class Esanghesi :PocketMon
    {
        public Esanghesi()
        {
            initPocketMon("Esanghesi", "Flower", 1, 10, 10, 10);
        }
        public Esanghesi(string _name)
        {
            initPocketMon(_name, "Flower", 1, 10, 10, 10);
        }
        
    }
}
