using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            singleton.AB.index = 1;
        }
    }
    class singleton
    {
        private static singleton instance;
        public static singleton AB
        {
            get
            {
                if(instance == null)
                {
                    instance = new singleton();
                }
                return instance;
            }
        }

        public int index = 0;
    }

    
}