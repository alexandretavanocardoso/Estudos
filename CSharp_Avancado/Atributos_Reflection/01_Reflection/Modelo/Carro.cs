using System;

namespace _01_Reflection.Modelo
{
    internal class Carro : ICloneable
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public object Clone()
        {
            return new Carro() { Marca = this.Marca, Modelo = this.Modelo};
        }
    }
}
