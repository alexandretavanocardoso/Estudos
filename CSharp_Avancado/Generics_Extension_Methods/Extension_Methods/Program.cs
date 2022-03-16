using Extension_Methods.Lib.Extesions;
using System;

namespace Extension_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valor = "extension é uma forma de criar novos métodos em classes de tipos de dados: nese caso é o String";
            valor.FirtsToUpper();

            string criacao = "public static string Nome(this String str) {}";

            Console.WriteLine(valor.FirtsToUpper());
            Console.WriteLine(criacao);
            Console.ReadKey();
        }
    }
}
