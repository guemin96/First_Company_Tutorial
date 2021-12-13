using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PocketMon.GameInstance;

namespace PocketMon
{
    public abstract class PocketManager
    {
        public abstract PocketMon Create(string _num, string _name);
        
    }
    class MyPocketMon : PocketManager
    {
        List<PocketMon> wildpocketMons = new List<PocketMon>();
        public override PocketMon Create(string _num, string _name)
        {
            switch(_num)
            {
                case "1": return new Pikachu(_name);
                case "2": return new Pairi(_name);
                case "3": return new Gobugi(_name);
                case "4": return new Esanghesi(_name);
            }
            return null;
        }
      
    }
}
