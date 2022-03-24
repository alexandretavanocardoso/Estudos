using System;

using System.Threading;

namespace _02_MultiThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);
                t1.Start();
            }

            Console.WriteLine("Finalizou");
            Console.ReadKey();
        }

        static void ThreadRepeticao()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("MultiThread:" + i);
            }
        }
    }
}
