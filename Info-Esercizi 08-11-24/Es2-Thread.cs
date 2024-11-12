using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Info_Esercizi_08_11_24
{
    class Es2Thread
    {
        private int Counter = 0;
        private Queue<int> Queue = new Queue<int>();
        private int QueueMaxLength = 10;
        private readonly object lckCounter = new object();

        public void Run()
        {
            Thread t1 = new Thread(() => { AddAndRemove(); });
            Thread t2 = new Thread(() => { AddAndRemove(); });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        private void AddAndRemove()
        {
            while (true)
            {
                lock (lckCounter)
                {
                    if (Queue.Count >= QueueMaxLength)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dequeued " + Queue.Dequeue());

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Queue.Enqueue(Counter);
                        Console.WriteLine("Enqueued " + Counter);
                        Counter++;
                    }

                    Task.Delay(1000);
                }
            }
        }        
    }
}
