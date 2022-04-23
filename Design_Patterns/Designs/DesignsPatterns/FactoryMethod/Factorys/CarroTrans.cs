using FactoryMethod.veiculos;

namespace FactoryMethod.Factorys
{
    internal class CarroTrans : Transpost
    {
        public override IVeiculos CreateTransport()
        {
            return new Carro();
        }
    }
}
