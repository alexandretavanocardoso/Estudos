using System;

namespace _02_Delegate.Lib
{
    public class FotoFiltro
    {
        public void Colorir(Foto foto)
        {
            // algoritmo
            Console.WriteLine("Coloriu");
            Console.ReadKey();
        }

        public void GerarThumb(Foto foto)
        {
            // algoritmo
            Console.WriteLine("Gerou Thumb");
            Console.ReadKey();
        }

        public void PretoBranco(Foto foto)
        {
            // algoritmo
            Console.WriteLine("Converteu");
            Console.ReadKey();
        }

        public void RedimensionarM(Foto foto)
        {
            // algoritmo
            Console.WriteLine("Redimensionou M");
            Console.ReadKey();
        }
    }
}
