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
            List<ITelefone> lstTelefone = new List<ITelefone>();
            Guid contatoId = Guid.NewGuid(); // Feito para gerar apenas uma Guid para cada interação
            Guid telefoneId = Guid.NewGuid(); // Feito para gerar apenas uma Guid para cada interação
            IContato contatoResultado;
            
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(contatoId); // Propriedade que vai retornar
            mContato.SetupGet(o => o.Nome).Returns("Alexandre"); // Propriedade que vai retornar
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                    .Callback<List<ITelefone>>(p => lstTelefone = p); // Propriedade que vai setar um valor + callback(inseri na variavel o telefone recebido)
            _contatos.Setup(o => o.Obter(It.IsAny<Guid>())).Returns(mContato.Object); // Retorna a função chamada

            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(telefoneId); // Propriedade que vai retornar
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234"); // Propriedade que vai retornar
            mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId); // Propriedade que vai retornar
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> {mTelefone.Object }); // Moq da função ObterTodos

            // EXECUTA
            contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            // VERIFICA
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mTelefone.Object.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mTelefone.Object.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
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
