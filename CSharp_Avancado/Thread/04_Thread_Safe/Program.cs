using System;
using System.Threading;

namespace _04_Thread_Safe
{
    internal class Program
    {
        // IO Input/Output = Entrada e Saida de dados - é um precesso lento e instável (Tela-Rede-Armazenamento)

        static int Rede = 0;
        static object variavelControle = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ThreadRepeticao);
                t1.IsBackground = true;
                t1.Start();
            }

            Console.ReadKey();
        }

        static void ThreadRepeticao()
        {
            // lock(): Estrutura do C# que reserva um recursos para ser utilizado por apenas uma thread por vez, garantindo segurança
            // Temos uma fila  ao utiliza-lo, FirstIn e FirstOut: Conceito(primeiro a entrar é o primeiro a sair)

            // variavelControle: Faz com que as threads não usem alguns recursos juntos 

            for (int i = 0; i < 1000; i++)
            {
                lock (variavelControle) // Reserva um recursos para ser utilizado por apenas uma thread por vez, garantindo segurança (REDE)
                {
                    Console.WriteLine("MultiThread:" + i);
                    Rede++;
                };
            }

            Console.WriteLine("Data:" + DateTime.Now);
        }
    }
}
