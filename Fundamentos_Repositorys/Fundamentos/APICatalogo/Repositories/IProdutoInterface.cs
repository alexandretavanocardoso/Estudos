using APICatalogo.Models;
using System.Collections;
using System.Collections.Generic;

namespace ApiCatalogo.Repositories
{
    public interface IProdutoInterface : IRepository<Produto>
    {
        IEnumerable<Produto> GetProduto();
    }
}
