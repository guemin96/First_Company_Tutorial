using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChattingClient.Class;

namespace ChattingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient c = new ConsoleClient();
            c.Run();
        }
    }
}
