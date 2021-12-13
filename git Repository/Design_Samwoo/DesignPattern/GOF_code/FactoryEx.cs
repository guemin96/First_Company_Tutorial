using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    class FactoryEx
    {
    }
    
    abstract class unit
    {

    }
    class marine : unit
    {

    }
    class firebat : unit
    {

    }
    class dropship : unit
    {

    }
    abstract class building
    {
        public abstract unit create(string _name);
    }
    class barreak : building
    {
        public override unit create(string _name)
        {
            switch (_name)
            {
                case "marine":
                    return new marine();
                    break;
                case "firebat":
                    return new firebat();
                    break;
                default:
                    break;
            }
            return null;
        }
    }
    class starport : building
    {
        public override unit create(string _name)
        {
            return new dropship();
        }
    }

}
