using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Info_Esercizi_08_11_24
{
    internal class Es1Task
    {
        private int Counter = 0;
        private readonly object lckCounter = new object();

        public void Run()
        {
            Task t1 = new Task(() => { NumeriPari(); });
            Task t2 = new Task(() => { NumeriDispari(); });

            t1.Start();
            t2.Start();
        }

        private void NumeriPari()
        {
            while (true)
            {
                lock (lckCounter)
                {
                    if (Counter % 2 == 0)
                    {
                        Console.WriteLine(Counter + "\n");
                    }
                    
                    Counter++;
                    Task.Delay(1000);
                }
            }
        }

        private void NumeriDispari()
        {
            while (true)
            {
                lock (lckCounter)
                {
                    if (Counter % 2 != 0)
                    {
                        Console.WriteLine(Counter + "\n");
                    }

                    Counter++;
                    Task.Delay(1000);                    
                }
            }
        }
    }
}