using System;

namespace _01_Delegates
{
    internal class Program
    {
        //  Os delegados especificam um método para chamar e, opcionalmente, um objeto para chamar o método
        //  Criando ponteiros seguros

        // Declaração
        delegate int Calcula(int a, int b);

        static void Main(string[] args)
        {
            // ponteiros delegate
            Calcula calcMais = new Calcula(Soma);
            int so = calcMais(10, 20);

            Calcula calcMenos = new Calcula(Subtrair);
            int su = calcMais(10, 20);


            Console.Write("Soma: {0}", so);
            Console.Write("Subtracao: {0}", su);
            Console.ReadKey();
        }

        static int Soma(int a, int b)
        {
            return a + b;
        }

        static int Subtrair(int a, int b)
        {
            return a - b;
        }
    }
}
