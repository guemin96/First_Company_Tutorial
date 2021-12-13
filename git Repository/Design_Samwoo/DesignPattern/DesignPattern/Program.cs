using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var myObject = ObjectFactory.Create();

            myObject.SomethingInteresting();

            var sb = new StringBuilder();

            var list = new List<string>();

            var someValueType = new SomeValueObject
            {
                Age = 100,
                Name = "Kevin"
            };
        }
    }
}
