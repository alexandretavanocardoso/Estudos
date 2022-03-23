using _02_Delegate.Lib;
using System;

namespace _02_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foto foto = new Foto() { Nome = "Foto.jpeg", TamanhoX = 1920, TamanhoY = 1080 };

            // Tela cadastro usuario: Thumb(Foto do perfil)
            FotoProcessador.filtros = new FotoFiltro().GerarThumb;
            FotoProcessador.Processar(foto);

            // Tela cadastro produto: Redimensionar + Coloridos
            FotoProcessador.filtros = new FotoFiltro().Colorir;
            FotoProcessador.filtros += new FotoFiltro().RedimensionarM;
            FotoProcessador.Processar(foto);

            // Tela cadastro albuns retro: preto e branco
            FotoProcessador.filtros = new FotoFiltro().PretoBranco;
            FotoProcessador.Processar(foto);

            Console.ReadKey();
        }
    }
}
