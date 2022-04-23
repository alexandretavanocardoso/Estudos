using Bridge.Plataforma;
using Bridge.Trasmissao;
using System;

namespace Bridge
{
    internal class Program
    {
        static void StartLive(IPlataforma plataforma)
        {
            Console.WriteLine("Aguarde");

            Livee live = new Livee(plataforma);

            live.BroadCasting();
            live.Result();
        }

        static void StartLiveAdvanced(IPlataforma plataforma)
        {
            Console.WriteLine("Aguarde");

            LiveAvancada live = new LiveAvancada(plataforma);

            live.BroadCasting();
            live.SubTitles();
            live.Comments();
            live.Result();
        }

        static void Main(string[] args)
        {
            StartLive(new Youtube());
            StartLiveAdvanced(new Facebook());

            Console.ReadLine();
        }
    }
}
