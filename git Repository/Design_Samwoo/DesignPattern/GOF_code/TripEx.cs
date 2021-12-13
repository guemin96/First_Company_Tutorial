using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    class TripEx
    {
    }
    abstract class trip
    {

    }
    class japan : trip
    {

    }
    class uk : trip
    {

    }
    class france : trip
    {

    }
    abstract class continent
    {
        public abstract trip createTrip(string _name);
    }
    //class 
    class Asia : continent
    {
        public override trip createTrip(string _name)
        {
            switch (_name)
            {
                case "japan":
                    return new japan();
                    break;
                default:
                    break;
            }
            return null;
        }
    }
    class Eureaop : continent
    {
        public override trip createTrip(string _name)
        {
            switch (_name)
            {
                case "uk":
                    return new uk();
                    break;
                case "france":
                    return new france();
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
