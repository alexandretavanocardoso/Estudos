using _01_Reflection.Modelo;
using System;
using System.Collections.Generic;

namespace _01_Reflection
{
    internal class Log
    {
        public static List<object> listObject = new List<object>();

        public static void Gravar(object obj)
        {
            listObject.Add(obj);
        }

        public static void ApresentarLog()
        {
            foreach (object objs in listObject)
            {
                Console.WriteLine("Nome Classe: {0}", objs.GetType().Name);

                foreach (var prop in objs.GetType().GetProperties())
                {
                    Console.WriteLine(prop.Name + ":" + prop.GetValue(objs));
                }
            }
        }

        /*
        public static List<Usuario> listUser = new List<Usuario>();
        public static void GravarUsuario(Usuario user)
        {
            listUser.Add((Usuario)user.Clone());
        }

        public static List<Carro> listCarro = new List<Carro>();
        public static void GravarUsuario(Carro carro)
        {
            listCarro.Add((Carro)carro.Clone());
        }   

        public static void ApresentarLog()
        {
            foreach (Usuario users in listUser)
            {
                Console.WriteLine("Nome: {0}, Email: {1}, Senha: {2}", users.Nome, users.Email, users.Senha);
            }

            foreach (Carro carros in listCarro)
            {
                Console.WriteLine("Modelo: {0}, Marca: {1}", carros.Modelo, carros.Marca);
            }
        }
        */
    }
}
