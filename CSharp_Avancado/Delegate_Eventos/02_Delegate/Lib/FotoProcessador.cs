using System;

namespace _02_Delegate.Lib
{
    class FotoProcessador
    {
        public delegate void FotoFiltroRendler(Foto foto);

        public static FotoFiltroRendler filtros;

        public static void Processar(Foto foto)
        {
            filtros(foto);
        }
    }
}
