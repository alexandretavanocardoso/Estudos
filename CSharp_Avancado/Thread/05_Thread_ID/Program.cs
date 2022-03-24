using System;
using System.Threading;

namespace _05_Thread_ID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);
                t1.Start(i); // Forma de passar parametro
            }

            Console.ReadKey();
        }

        static void ThreadRepeticao(object id)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("ThreadID:" + id + " " + "MultiThread:" + i + " " + "Thread ID Interno:" + Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
