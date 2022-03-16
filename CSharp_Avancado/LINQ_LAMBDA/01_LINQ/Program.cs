using System;
using System.Linq;

namespace _01_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LINQ - Bilioteca que tem semelhança com SQL
            // LAMBDA - expressões em partes do código, muito utilizado no LINQ (entradaDados) => (expressaoDados)

            int[] lista = { 1,4,59,6,2,3,4,5};

            var listaFiltrada = lista.Where(n => n > 2)
                                     .OrderBy(n => n)
                                     .Select(n => n);

            foreach (var item in listaFiltrada)
            {
                Console.WriteLine("Numeros: {0}", item);
            }

            Console.ReadKey();
        }
    }
}
