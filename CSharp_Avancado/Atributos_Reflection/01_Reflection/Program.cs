using _01_Reflection.Modelo;
using System;

namespace _01_Reflection
{
    internal class Program
    {
        // Reflection: Se auto girencia, pode ler classes, atribuir valores para classe, pesquisar algo, instanciar objetos, utilizar estruturas, ler campos, logs
        // Permite ter flexibilidade ao código

        static void Main(string[] args)
        {
            Usuario user = new Usuario() { Nome = "Alexandre", Email = "Alexadre@email", Senha = "123456AED" };
            Log.Gravar(user.Clone());

            user.Nome = "Alexandre Tavano";
            Log.Gravar(user.Clone());


            Carro carro = new Carro() { Marca = "Fiat", Modelo = "UNO" };
            Log.Gravar(carro.Clone());

            Log.ApresentarLog();

            Console.WriteLine("Log gravado");
            Console.ReadKey();
        }
    }
}
