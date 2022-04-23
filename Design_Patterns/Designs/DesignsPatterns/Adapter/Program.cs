using System;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaypalPayment payment = new Adapter(new PyonnerPayment());
            payment.payPalPayment();
            payment.payPalReceive();

            Console.ReadLine();
        }
    }
}
