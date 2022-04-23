using System;

namespace Adapter
{
    class PyonnerPayment : IPyonnerPayment
    {
        private Token token;
        public Token AuthToken()
        {
            return new Token();
        }

        public void ReceivePayment()
        {
            Console.WriteLine("Recebendo com pyonner");
        }

        public void SendPayment()
        {
            token = AuthToken();
            Console.WriteLine("Pagando com pyonner");
        }
    }
}
