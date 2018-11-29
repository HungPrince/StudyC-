using System;
using System.Threading;

namespace MyThread
{
    class Program
    {
        public class MThread
        {
            public static void MethodThread()
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread t = Thread.CurrentThread;
                    Thread.Sleep(200);
                    Console.WriteLine(t.Name + " is running");
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(MThread.MethodThread));
            Thread t2 = new Thread(new ThreadStart(MThread.MethodThread));
            Thread t3 = new Thread(new ThreadStart(MThread.MethodThread));
            t1.Name = "Player 1";
            t2.Name = "Player 2";
            t3.Name = "Player 3";
            t3.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Normal;
            t1.Priority = ThreadPriority.Lowest;
            t1.Start();
            t2.Start();
            t3.Start(); 
           
            Console.ReadKey(true);
        }
    }
}
