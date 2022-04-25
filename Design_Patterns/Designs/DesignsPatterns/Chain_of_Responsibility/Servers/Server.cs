using Chain_of_Responsibility.Midllewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility.Servers
{
    class Server
    {
        private Dictionary<string, string> users = new Dictionary<string, string>();
        private Middleware middleware;

        public void SetMiddleware(Middleware middleware)
        {
            this.middleware = middleware;
        }

        public Boolean login(string email, string senha)
        {
            if (middleware.Check(email, senha))
            {
                Console.WriteLine("Seja bem vindo");

                return true;
            }

            return false;
        }

        public void Register(string email, string senha)
        {
            users[email] = senha;
        }

        public Boolean TemEmail(string email)
        {
            return users.ContainsKey(email);
        }

        public Boolean SenhaValida(string email, string senha)
        {
            string value = "";

            users.TryGetValue(email, out value);

            return senha == value;
        }
    }
}
