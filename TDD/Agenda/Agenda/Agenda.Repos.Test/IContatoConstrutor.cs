using Agenda.Domain.Interfaces;
using System;

namespace Agenda.Repos.Test
{
    public class IContatoConstrutor : IBaseConstrutor<IContato>
    {
        protected IContatoConstrutor() : base() { }

        public static IContatoConstrutor Um()
        {
            return new IContatoConstrutor();
        }

        public IContatoConstrutor ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome); // Propriedade que vai retornar
            return this;
        }

        public IContatoConstrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id); // Propriedade que vai retornar
            return this;
        }
    }
}
