using System;
using System.IO;
using System.Xml.Serialization;
using _00_Bilbioteca;

namespace _02_Deserializar_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\Arquivo_XML\01_Serializar.xml");

            XmlSerializer serializador = new XmlSerializer(typeof(Usuario));

            // deserializando e fazendo um "cast" para deserializar ser do típo Usuario
            Usuario user = (Usuario)serializador.Deserialize(streamReader);

            // mostrando dados deserializados
            Console.WriteLine("Usuario(Nome) {0}, CPF {1}, Email {2}", user.Nome, user.CPF, user.Email);
            Console.ReadKey();
        }
    }
}
