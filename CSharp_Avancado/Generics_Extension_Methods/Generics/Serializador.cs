using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Serializador
    {
        public static void Serializar(Object obj)
        {
            StreamWriter stream = new StreamWriter(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\" + obj.GetType().Name + ".txt");

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string stringObj = serializer.Serialize(obj);

            stream.Write(stringObj);
            stream.Close();
        }

        public static T Deserializar<T>()
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\tavan\OneDrive\Área de Trabalho\CSharp_Avancado\" + typeof(T).Name + ".txt");
            string conteudo = streamReader.ReadToEnd();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T obj = (T)serializer.DeserializeObject(conteudo);

            return obj;
        }
    }
}
