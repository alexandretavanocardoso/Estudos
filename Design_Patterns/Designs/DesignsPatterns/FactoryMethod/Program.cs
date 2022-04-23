using FactoryMethod.Factorys;
using System;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transpost transpost = null;

            if (args.Length > 0 && args[0] == "--uber")
            {
                transpost = new CarroTrans();
            } else if(args.Length > 0 && args[0] == "--log")
            {
                transpost = new MotoTrans();
            }
            else
            {
                Console.WriteLine("Selecione o serviço");
            }

            if (transpost != null) transpost.StartTransport();

            Console.ReadLine();
        }
    }
}
