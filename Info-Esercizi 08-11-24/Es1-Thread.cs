using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Info_Esercizi_08_11_24
{
    class Es1Thread
    {
        private int Counter = 0;
        private readonly object lckCounter = new object();

        public void Run()
        {
            Thread t1 = new Thread(() => { NumeriPari(); });
            Thread t2 = new Thread(() => { NumeriDispari(); });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        private void NumeriPari()
        {
            while(true)
            {
                lock (lckCounter)
                {
                    if (Counter % 2 == 0)
                    {
                        Console.WriteLine(Counter + "\n");
                    }

                    Thread.Sleep(100);
                    Counter++;
                }
            }
            
            
        }

        private void NumeriDispari()
        {
            while(true) {
                lock (lckCounter)
                {
                    if (Counter % 2 != 0)
                    {
                        Console.WriteLine(Counter + "\n");                        
                    }

                    Thread.Sleep(100);
                    Counter++;
                }
            }

        }
    }
}
