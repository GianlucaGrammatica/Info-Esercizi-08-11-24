using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Info_Esercizi_08_11_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Es 1 Thread
            //new Es1Thread().Run();

            //Es 1 Task
            new Es1Task().Run();


            Console.ReadKey();
        }
    }
}
