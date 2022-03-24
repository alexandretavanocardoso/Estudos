using System;
using System.Threading;

namespace _06_Thread_Metodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thread Sleep
            // Determina o tempo que as threads tem que esperar para prosseguir a execução
            Thread.Sleep(3000);

            // Thread Join
            // Espera a thread finalizar para executar o fluxo padrao
            Thread t1 = new Thread(ThreadRepeticao);
            t1.Start(1);
            t1.Join();
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
