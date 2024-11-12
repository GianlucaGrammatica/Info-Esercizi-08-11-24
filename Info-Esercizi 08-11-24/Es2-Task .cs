using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Info_Esercizi_08_11_24
{
    internal class Es2Task
    {
        private int Counter = 0;
        private Queue<int> Queue = new Queue<int>();
        private int QueueMaxLength = 10;
        private readonly object lckCounter = new object();

        public void Run()
        {
            Task t1 = new Task(() => { AddAndRemove(); });
            Task t2 = new Task(() => { AddAndRemove(); });

            t1.Start();
            t2.Start();

            Task.WaitAll();
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
                }
            }
        }
    }
}

