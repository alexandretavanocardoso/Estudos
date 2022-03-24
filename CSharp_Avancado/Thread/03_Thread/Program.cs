using System;

using System.Threading;

namespace _03_Thread_BackGround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);

                // Todas threads vão ser executadas enquanto o fluxo principal for executado
                // Ficam dependendes da classe MAIN
                t1.IsBackground = true;
                
                t1.Start();
            }

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
