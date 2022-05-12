using Agenda.Domain.Interfaces;
using AutoFixture;
using System;

namespace Agenda.Repos.Test
{
    public class ITelefoneConstrutor : IBaseConstrutor<ITelefone>
    {
        protected ITelefoneConstrutor() : base() {}

        public static ITelefoneConstrutor Um()
        {
            return new ITelefoneConstrutor();
        }

        public ITelefoneConstrutor Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());

            return this;
        }

        public ITelefoneConstrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id); // Propriedade que vai retornar
            return this;
        }

        public ITelefoneConstrutor ComNumero(string numero){
            _mock.SetupGet(o => o.Numero).Returns(numero); // Propriedade que vai retornar
            return this;
        }

        public ITelefoneConstrutor ComContatoId(Guid ContatoId)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(ContatoId); // Propriedade que vai retornar
            return this;
        }
    }
}
