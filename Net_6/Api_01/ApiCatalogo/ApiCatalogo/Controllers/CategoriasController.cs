using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("retornarTodasCategorias")]
        public ActionResult<IEnumerable<CategoriaModel>> RetornarTodasCategorias()
        {
            return _context.Categorias?.AsNoTracking().ToList();
        }

        [HttpGet("retornarCategoriaPorId")]
        public ActionResult<CategoriaModel> RetornarCategoriaPorId(decimal id)
        {
            try
            {
                var categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == id);

                if (categoria is null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpGet("retornarCategoriasPorProduto")]
        public ActionResult<IEnumerable<CategoriaModel>> RetornarCategoriasPorProduto()
        {
            return _context.Categorias?.Include(p => p.Produtos).ToList();
        }

        [HttpPost("adicionarCategoria")]
        public ActionResult AdicionarCategoria(CategoriaModel categoriaModel)
        {
            try
            {
                if (categoriaModel is null)
                    return BadRequest();

                _context.Categorias?.Add(categoriaModel);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpPut("alterarCategoria")]
        public ActionResult AlterarCategoria(CategoriaModel categoriaModel)
        {
            try
            {
                if (categoriaModel is null)
                    return BadRequest();

                var categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == categoriaModel.CategoriaId);

                if (categoria is null)
                    return BadRequest();

                _context.Categorias?.Update(categoria);
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }

        [HttpDelete("deletarCategoria")]
        public ActionResult DeletarCategoria(decimal id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                var categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == id);

                if (categoria is null)
                    return BadRequest();

                _context.Categorias?.Remove(categoria);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Mensagem");
            }
        }
    }
}
