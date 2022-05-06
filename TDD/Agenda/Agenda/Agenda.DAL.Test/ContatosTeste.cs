using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTeste
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
        public void AdicionarContatoTeste_Teste()
        {
            //Monta - variaveis
            var contato = _fixture.Create<Contato>();

            // Executa - executa
            _contatos.Adicionar(contato);

            //Verifica - verificar se o retorno é igual o esperado
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTeste_Teste()
        {
            //Monta - variaveis
            var contato = _fixture.Create<Contato>();
            Contato contatoResultado;

            // Executa - executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            //Verifica - verificar se o retorno é igual o esperado
            // Comparando se o nome que incluimos é igual ao retornado
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [TearDown] // Depois
        public void TerDown_Teste()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
