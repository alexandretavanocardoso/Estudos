using System;

namespace _01_Atributo
{
    internal class Program
    {
        // Atributo Criado
        [MeuAtributo("Classe", Descricao = "Descricao Atributo")]
        static void Main(string[] args)
        {
            Console.WriteLine("Atributo é um metadado ue serve pra explicar ou gerar informação sobre outra parte do código");

            Console.WriteLine("Pode gerar Validacao - Documentacao");
        }
    }
}
