using System;

namespace FactoryMethod.veiculos
{
    internal class Moto : IVeiculos
    {
        public void GetCargo()
        {
            Console.WriteLine("Pegamos os passageiros");
        }

        public void StartRoute()
        {
            GetCarg();
            Console.WriteLine("Iniciamos trajeto");
        }
    }
}
