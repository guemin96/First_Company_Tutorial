using System;
using System.Collections.Generic;
using System.Text;

namespace GOF_code
{
    class Target// 새로운 유닛
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }
    class Adapter : Target // 유닛 전체
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }
    class Adaptee // 옛날 유닛
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
