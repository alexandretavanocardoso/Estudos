using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility.Midllewares
{
    abstract class Middleware
    {
        private Middleware next;

        public Middleware LinkWith(Middleware next)
        {
            this.next = next;

            return next;
        }

        public abstract Boolean Check(string email, string senha);
        protected Boolean CheckNext(string email, string senha)
        {
            if (next == null)
                return true;

            return next.Check("email", "senha");

        }
    }
}
