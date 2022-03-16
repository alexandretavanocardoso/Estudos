using System;
using Generics.Modelos;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro() { Marca = "Fiat", Modelo = "UNO"};
            Casa casa = new Casa() { Cidade = "Brasilia", Endereco = "Rua 400"};
            Usuario usuario = new Usuario() { Nome = "Alexandre", Email = "alexandre@outlook.com", Senha = "123456"};

            Serializador.Serializar(carro);
            Serializador.Serializar(casa);
            Serializador.Serializar(usuario);

            Carro carro2 = Serializador.Deserializar<Carro>();
            Casa casa2 = Serializador.Deserializar<Casa>();
            Usuario usuario2 = Serializador.Deserializar<Usuario>();

            Console.WriteLine("Marca: {0}", carro2.Marca);
            Console.WriteLine("Cidade: {0}", casa2.Cidade);
            Console.WriteLine("Nome: {0}", usuario2.Nome);
            Console.ReadKey();
        }
    }
}
