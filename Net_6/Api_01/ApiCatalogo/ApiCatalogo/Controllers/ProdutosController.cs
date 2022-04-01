using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("retornarTodosProdutos")]
        public ActionResult<IEnumerable<ProdutoModel>> RetornarTodosProdutos()
        {
            try
            {
                var produtos = _context.Produtos?.AsNoTracking().ToList();

                if (produtos is null)
                    return NotFound("Produtos não encontrados"); // 404

                return produtos;
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpGet("retornarProdutoPorId")]
        public ActionResult<ProdutoModel> RetornarProdutoPorId(decimal id)
        {
            try
            {
                var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);

                if (produto is null)
                    return NotFound("Produto não encontrado");

                return produto;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpPost(Name = "adicionarProdutos")]
        public ActionResult AdicionarProdutos(ProdutoModel produtoModel)
        {
            try
            {
                if (produtoModel is null)
                    return BadRequest("Produto não encontrado");

                _context.Produtos?.Add(produtoModel);
                _context.SaveChanges();

                // Retorna 201 e Chama o método passado e retornar também o que foi mandado, nesse caso o produto adicionado
                return new CreatedAtRouteResult("retornarProdutoPorId", new { id = produtoModel.ProdutoId, }, produtoModel);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpPut(Name = "alterarProdutos")]
        public ActionResult AlterarProdutos(ProdutoModel produtoModel)
        {
            try
            {
                if (produtoModel is null)
                    return BadRequest("Produto não encontrado");

                _context.Entry(produtoModel).State = EntityState.Modified; // faz com persista que seja uma atualizacao
                _context.SaveChanges();

                return Ok(produtoModel);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpDelete(Name = "deletarProduto")]
        public ActionResult DeletarProduto(decimal id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);

                if (produto is null)
                    return NotFound("Produto não localizado");

                _context.Produtos?.Remove(produto);
                _context.SaveChanges();

                return Ok();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }
    }
}
