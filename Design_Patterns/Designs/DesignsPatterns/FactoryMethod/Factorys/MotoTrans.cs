using FactoryMethod.veiculos;

namespace FactoryMethod.Factorys
{
    internal class MotoTrans : Transpost
    {
        public override IVeiculos CreateTransport()
        {
            return new Moto();
        }
    }
}
