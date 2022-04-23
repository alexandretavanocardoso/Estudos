using System;

namespace Bridge.Plataforma
{
    class Facebook : IPlataforma
    {
        public Facebook()
        {
            ConfigureRMTP();
            Console.WriteLine("Iniciada!");
        }

        public void AuthToken()
        {
            Console.WriteLine("Facebook autorizando!");
        }

        public void ConfigureRMTP()
        {
            AuthToken();
            Console.WriteLine("Configurando servidor do Facebook");
        }
    }
}
