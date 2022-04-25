using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility.Midllewares
{
    class CheckPermissionMiddleware : Middleware
    {
        public override bool Check(string email, string senha)
        {
            if(email == "admin")
            {
                Console.WriteLine("é admin");
                return true;
            }

            Console.WriteLine("Bem vindo");
            return CheckNext(email, senha);
        }
    }
}
