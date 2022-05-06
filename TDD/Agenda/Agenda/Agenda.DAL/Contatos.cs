using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Domain;
using Dapper;

namespace Agenda.DAL
{
    public class Contatos
    {
        private string _conexao;

        public Contatos()
        {
            _conexao = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            using(var con = new SqlConnection(_conexao))
            {
                con.Execute("INSERT INTO CONTATO(ID, NOME) VALUES(@ID, @NOME)", new {ID = contato.Id, NOME = contato.Nome});
            }   
        }

        public Contato Obter(Guid id) 
        {
            Contato contato;
            using (var con = new SqlConnection(_conexao))
            {
                contato = con.QueryFirst<Contato>("SELECT ID, NOME FROM CONTATO WHERE ID = @ID", new {ID = id});
            }

            return contato;
        }

        public List<Contato> ObterLista()
        {
            var contatoLista = new List<Contato>();

            using (var con = new SqlConnection(_conexao))
            {
                contatoLista = con.Query<Contato>("SELECT ID, NOME FROM CONTATO", new {}).ToList();
            }

            return contatoLista;
        }
    }
}
