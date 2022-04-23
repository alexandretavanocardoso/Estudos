using System;

namespace Adapter
{
    class PaypalPayment : IPaypalPayment
    {
        private Token token;

        public Token authToken()
        {
            return new Token();
        }

        public void payPalPayment()
        {
            token = authToken();
            Console.WriteLine("Enviando pagamento com paypal");
        }

        public void payPalReceive()
        {
            Console.WriteLine("Recebendo pagamento com paypal");
        }
    }
}
