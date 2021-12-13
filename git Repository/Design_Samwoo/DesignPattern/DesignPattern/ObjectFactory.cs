using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DesignPattern
{
    public static class ObjectFactory
    {
        public static IBusineessThingy Create()
        {
            var someSettings = Convert.ToBoolean(ConfigurationManager.AppSettings["foo"]);
            if (someSettings)
            {
                return new ConcreteBusinessObject("foo");
            }
            else
            {
                return new SecondConcreteBusinessObject();
            }
        }
    }
}
