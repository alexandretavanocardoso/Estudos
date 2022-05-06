using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Teste
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp] // Antes
        public void Setup_Teste()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterContatoLista_Teste()
        {
            var contato1 = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContatos = _contatos.ObterLista();
            var contatoResultado = lstContatos.Where(o => o.Id == contato1.Id).First();

            //Assert.AreEqual(2, lstContatos.Count());
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown] // Depois
        public void TerDown_Teste()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
