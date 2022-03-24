using System;
using System.Threading;

namespace _07_Thread_Sincronization
{
    internal class Program
    {
        // Clases que geram dependencias entre as threads

        // Não é necessario travamento, sempre que acontece a liberação ele ja trava Set() + Reset()
        static AutoResetEvent autoResetEvent;

        // No manual para fazer o travamento é necessario usar o Reset();
        static ManualResetEvent manualResetEvent;

        static void Main(string[] args)
        {
            manualResetEvent = new ManualResetEvent(false);
            autoResetEvent = new AutoResetEvent(false);

            Thread t1 = new Thread(Execucao1);
            t1.Start();

            Thread t2 = new Thread(Execucao2);
            t2.Start();

            Thread.Sleep(5000);
            manualResetEvent.Set(); // Libera o que foi liberado 
            manualResetEvent.Reset();  // A ideia é que resetar o ManualResetEvent, travar uma parte da execucao

            Thread.Sleep(5000);
            autoResetEvent.Set();

            Thread.Sleep(5000);
            manualResetEvent.Set();
            autoResetEvent.Set();

            Console.ReadKey();
        }

        static void Execucao1()
        {
            Console.WriteLine("01 - Iniciado Execucao1");
            
            manualResetEvent.WaitOne(); // Esperar que seja liberados

            Console.WriteLine("02 - Em execucao Execucao1");
            Console.WriteLine("03 - Em execucao Execucao1");

            manualResetEvent.WaitOne(); // Esperar que seja liberados

            Console.WriteLine("04 - Finalizado");
        }

        static void Execucao2()
        {
            Console.WriteLine("01 - Iniciado Execucao1");

            autoResetEvent.WaitOne();
            
            Console.WriteLine("02 - Em execucao Execucao2");
            Console.WriteLine("03 - Em execucao Execucao2");
            
            autoResetEvent.WaitOne();
         
            Console.WriteLine("04 - Finalizado");
        }
    }
}
