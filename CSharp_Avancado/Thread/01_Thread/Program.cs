using System;

using System.Threading;

namespace _01_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadRepeticao);
            t1.Start(); // Inicia Thread "ThreadRepeticao"

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main:" + i);
            }

            Console.ReadKey();
        }

        static void ThreadRepeticao()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Num:" + i);
            }
        }
    }
}
