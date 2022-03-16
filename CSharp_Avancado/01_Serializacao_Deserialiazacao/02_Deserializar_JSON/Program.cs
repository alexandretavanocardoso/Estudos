using _00_Bilbioteca;
using Nancy.Json;
using System;
using System.IO;

namespace _02_Deserializar_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\Arquivo_JSON\01_Serializar.json");
            string linhasArquivos = streamReader.ReadToEnd();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Usuario usuario = serializer.Deserialize<Usuario>(linhasArquivos);

            Console.WriteLine("Usuario(Nome) {0}, CPF {1}, Email {2}", usuario.Nome, usuario.CPF, usuario.Email);
            Console.ReadKey();
        }
    }
}
