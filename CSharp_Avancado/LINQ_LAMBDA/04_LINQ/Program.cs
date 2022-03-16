using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Livro> livroList = new List<Livro>();
            livroList.Add(new Livro() { IdLivro = 1, Titulo = "Clean Code", Ano = "2022", AutorId = 1 });
            livroList.Add(new Livro() { IdLivro = 2, Titulo = "Architeture Code", Ano = "2021", AutorId = 2 });
            livroList.Add(new Livro() { IdLivro = 3, Titulo = "Design Patterns", Ano = "2022", AutorId = 1 });
            livroList.Add(new Livro() { IdLivro = 4, Titulo = "Rest API", Ano = "2022", AutorId = 3 });

            List<Autor> autorList = new List<Autor>();
            autorList.Add(new Autor() { IdAutor = 1, Nome = "Alex"});
            autorList.Add(new Autor() { IdAutor = 2, Nome = "Guilherme"});
            autorList.Add(new Autor() { IdAutor = 3, Nome = "Robs"});

            var listaJoin = from livro in livroList join autor in autorList on livro.AutorId equals autor.IdAutor select new { livro, autor}; // equals = "=="

            foreach (var item in listaJoin)
            {
                Console.WriteLine("Livro: {0} - Autor: {1}", item.livro.Titulo, item.autor.Nome);
            }

            Console.ReadKey();
        }
    }
}
