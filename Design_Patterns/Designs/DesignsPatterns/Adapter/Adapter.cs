using System;

namespace Adapter
{
    class Adapter : IPaypalPayment
    {
        private PyonnerPayment _pyonnerPayment;
        public Adapter(PyonnerPayment pyonnerPayment)
        {
            _pyonnerPayment = pyonnerPayment;
        }

        public Token authToken()
        {
            return _pyonnerPayment.AuthToken();
        }

        public void payPalPayment()
        {
            _pyonnerPayment.SendPayment();
        }

        public void payPalReceive()
        {
            _pyonnerPayment.ReceivePayment();
        }
    }
}
