using _00_Bilbioteca;
using Nancy.Json;
using System.IO;

namespace _01_Serializar_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario user = new Usuario()
            {
                Nome = "Alexandre Tavano",
                Email = "tavanoalexandre@outlook.com.br",
                CPF = "222.222.222-22"
            };

            // serializando

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // salvando em string
            string stringObjSerializado =  serializer.Serialize(user);

            // salvando arquivo
            StreamWriter stream = new StreamWriter(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\Arquivo_JSON\01_Serializar.json");

            //lendo e fechando dados da memoria
            stream.WriteLine(stringObjSerializado);
            stream.Close();
        }
    }
}
