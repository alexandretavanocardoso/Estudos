using Chain_of_Responsibility.Midllewares;
using Chain_of_Responsibility.Servers;
using System;

namespace Chain_of_Responsibility
{
    internal class Program
    {
        private static Server server; 
        static void init()
        {
            server = new Server();
            server.Register("email", "senha");

            Middleware middleware = new CheckUserMiddleware(server);

            middleware.LinkWith(new CheckPermissionMiddleware());

            server.SetMiddleware(middleware);
        }

        static void Main(string[] args)
        {
            init();

            Boolean done = false;

            do
            {
                Console.WriteLine("Digite seu email");
                var email = Console.ReadLine();

                Console.WriteLine("Digite sua senha");
                var senha = Console.ReadLine();

                done = server.login(email, senha);

            } while (!done);

            Console.ReadLine();
        }
    }
}
