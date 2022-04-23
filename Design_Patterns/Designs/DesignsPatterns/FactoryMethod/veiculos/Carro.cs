using System;

namespace FactoryMethod.veiculos
{
    public class Carro : IVeiculos
    {
        public void GetCargo()
        {
            Console.WriteLine("Pegamos os passageiros");
        }

        public void StartRoute()
        {
            GetCargo();
            Console.WriteLine("Iniciamos trajeto");
        }
    }
}
