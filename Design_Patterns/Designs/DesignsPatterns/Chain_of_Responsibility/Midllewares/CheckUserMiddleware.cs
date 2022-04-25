using Chain_of_Responsibility.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility.Midllewares
{
    class CheckUserMiddleware : Middleware
    {
        private Server servers;
        public CheckUserMiddleware(Server servers)
        {
            this.servers = servers;
        }

        public override bool Check(string email, string senha)
        {
            if (!servers.TemEmail(email))
            {
                Console.WriteLine("Invalido");
                return false;
            }

            if(!servers.SenhaValida(email, senha))
            {
                Console.WriteLine("email ou senha inválidos");
                return false;
            }

            return CheckNext(email, senha);
        }
    }
}
