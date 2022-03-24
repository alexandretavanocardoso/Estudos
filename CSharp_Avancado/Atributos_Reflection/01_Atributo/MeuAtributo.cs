using System;

namespace _01_Atributo
{
    // Onde posso usar meus atributos
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    internal class MeuAtributo : Attribute
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public MeuAtributo(string nome)
        {
            Nome = nome;
        }
    }
}
