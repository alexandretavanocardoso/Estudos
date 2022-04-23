using System;

namespace Bridge.Plataforma
{
    class Youtube : IPlataforma
    {
        public Youtube()
        {
            ConfigureRMTP();
            Console.WriteLine("Iniciada!");
        }

        public void AuthToken()
        {
            Console.WriteLine("Youtube autorizando!");
        }

        public void ConfigureRMTP()
        {
            AuthToken();
            Console.WriteLine("Configurando servidor do Youtube");
        }
    }
}
