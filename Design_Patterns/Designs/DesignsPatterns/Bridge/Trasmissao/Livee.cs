using Bridge.Plataforma;
using System;

namespace Bridge.Trasmissao
{
    class Livee : ITransmissao
    {
        protected IPlataforma plataforma;
        public Livee(IPlataforma plataforma)
        {
            this.plataforma = plataforma;
        }

        public void BroadCasting()
        {
            Console.WriteLine("Iniciando Transmissão: " + plataforma);
        }

        public void Result()
        {
            Console.WriteLine("*** NO AE ***");
        }
    }
}
