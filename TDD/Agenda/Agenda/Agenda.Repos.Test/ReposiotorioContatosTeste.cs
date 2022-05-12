using Agenda.DAL.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Repos.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class ReposiotorioContatosTeste
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;

        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void Setup_Test()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();

            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone_Test()
        {
            var lstTelefone = new List<ITelefone>();
            var contatoId = Guid.NewGuid();
            var telefoneId = Guid.NewGuid();

            var mockContato = IContatoConstrutor.Um()
                                                .ComId(contatoId)
                                                .ComNome("Alexandre")
                                                .ObterMock();
            mockContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                       .Callback<List<ITelefone>>(p => lstTelefone = p); // Propriedade que vai setar um valor + callback(inseri na variavel o telefone recebido)
            _contatos.Setup(o => o.Obter(It.IsAny<Guid>())).Returns(mockContato.Object); // Retorna a função chamada

            var mockTelefone = ITelefoneConstrutor.Um()
                                                  .Padrao()
                                                  .ComId(telefoneId)
                                                  .ComContatoId(contatoId)
                                                  .Construir();
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mockTelefone }); // Moq da função ObterTodos

            var contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mockContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            Assert.AreEqual(mockContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mockContato.Object.Nome, contatoResultado.Nome);
            
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mockContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown_Test()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
