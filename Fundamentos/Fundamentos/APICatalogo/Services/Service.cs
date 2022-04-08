using System;

namespace ApiCatalogo.Services
{
    public class Service : IService
    {
        public string Saudacao(string nome)
        {
            return nome;
        }
    }
}
