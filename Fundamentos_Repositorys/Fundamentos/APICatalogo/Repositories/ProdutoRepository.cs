using APICatalogo.Context;
using APICatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCatalogo.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoInterface
    {
        readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Produto> GetProduto()
        {
            return Get().OrderBy(c => c.DataCadastro).ToList();
        }
    }
}
