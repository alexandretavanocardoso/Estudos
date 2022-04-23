using FactoryMethod.veiculos;

namespace FactoryMethod.Factorys
{
    abstract class Transpost
    {
        public void StartTransport() {
            IVeiculos veiculos = CreateTransport();
            veiculos.StartRoute();
        }

        public abstract IVeiculos CreateTransport();
    }
}
