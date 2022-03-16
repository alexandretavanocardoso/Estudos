using System;
using _00_Bilbioteca;

// importacoes
using System.IO; // ler/criar arquivos
using System.Xml.Serialization; // serializa em XML

namespace _01_Serializar_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario user = new Usuario()
            {
                Nome = "Alexandre",
                Email = "tavanoalexandre@outlook.com",
                CPF = "222.222.222-2"
            };

            // salvando o objeto e o tipo em xml
            XmlSerializer serializador = new XmlSerializer(user.GetType());

            // caminho em stream para gerar arquivo
            StreamWriter stream = new StreamWriter(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\Arquivo_XML\01_Serializar.xml");

            // serializando
            serializador.Serialize(stream, user);
        }
    }
}
