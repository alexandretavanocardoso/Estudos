using Bridge.Plataforma;
using System;

namespace Bridge.Trasmissao
{
    class LiveAvancada : Livee
    {
        public LiveAvancada(IPlataforma plataforma) : base(plataforma)
        {
        }

        public void SubTitles()
        {
            Console.WriteLine("Legendas ativadas");
        }

        public void Comments()
        {
            Console.WriteLine("Comentarios ativados");
        }
    }
}
