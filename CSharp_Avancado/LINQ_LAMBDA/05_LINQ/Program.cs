using System;
using System.Linq;

namespace _05_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] listaNumeros = { 1, 1, 2, 3, 4, 5, 6, 6 };

            // GROUP - DISTINCT

            var listaDistinct = listaNumeros.Distinct().OrderBy(a => a).Select(a => a);
            foreach (var item in listaDistinct)
            {
                Console.WriteLine("numeros: {0}", item);
            }

            // temos que ordenar antes de agrupar
            var listaGroup = listaNumeros.OrderBy(a => a).GroupBy(a => a).Select(a => a);
            foreach (var item in listaGroup)
            {
                Console.WriteLine("numeros: {0}", item.Key); // tem.key (valor)
            }

            Console.ReadKey();
        }
    }
}
