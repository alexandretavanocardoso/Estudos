using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> list = new List<Usuario>();
            list.Add(new Usuario() { Nome = "Jose", Email = "Jose@email"});
            list.Add(new Usuario() { Nome = "Maria", Email = "Maria@gmail" });
            list.Add(new Usuario() { Nome = "Wigor", Email = "Wigor@gmail" });
            list.Add(new Usuario() { Nome = "Jao", Email = "Jao@email" });
            list.Add(new Usuario() { Nome = "Cleide", Email = "Cleide@email" });

            var listaGmail = list.Where(g => g.Email.Contains("@gmail")).OrderBy(g => g.Nome).Select(g => g);

            foreach (var gmail in listaGmail)
            {
                Console.WriteLine("Nome de usurio com Gmail: {0} - {1}", gmail.Nome, gmail.Email);
            }

            Console.ReadKey();
        }
    }
}
