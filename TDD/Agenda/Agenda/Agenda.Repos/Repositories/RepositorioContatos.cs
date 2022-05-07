using Agenda.DAL.Interfaces;
using Agenda.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Agenda.Repos.Repositories
{
    public class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid id)
        {
            IContato contatos = _contatos.Obter(id);
            List<ITelefone> lstTelefones = _telefones.ObterTodosDoContato(id);

            contatos.Telefones = lstTelefones;

            return contatos;
        }
    }
}
