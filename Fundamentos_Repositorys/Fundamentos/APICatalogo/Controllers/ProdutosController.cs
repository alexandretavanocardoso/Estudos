using ApiCatalogo.Dtos;
using ApiCatalogo.Filters;
using APICatalogo.Context;
using APICatalogo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProdutosController(AppDbContext contexto, IMapper mapper)
        {
            _context = contexto;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProdutoDto>> GetDto(int id)
        {
            var produtos = _context.Produtos?.ToList();
            var produoDto = _mapper.Map<ProdutoDto>(produtos);

            return produoDto;
        }

        // api/produtos
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))] // atribui o filtro criado dos loggers
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }   
        
        // api/produtos/1
        // restrições de rotas
        // só é usado para distinguir rotas iguais
        [HttpGet("{id:int:min(1)}", Name ="ObterProduto")]
        [HttpGet("{id:int:max(1)}", Name ="ObterProduto")]
        [HttpGet("{param:alpha:length(5)}", Name = "ObterProduto")] // A até Z
        [HttpGet("{param:alpha:maxlength(5)}", Name = "ObterProduto")]
        [HttpGet("{param:alpha:minlength(5)}", Name = "ObterProduto")]
        [HttpGet("{param:bool", Name = "ObterProduto")]
        [HttpGet("{param:datetime}", Name = "ObterProduto")]
        [HttpGet("{param:decimal}", Name = "ObterProduto")]
        [HttpGet("{param:double}", Name = "ObterProduto")]
        [HttpGet("{param:float}", Name = "ObterProduto")]
        [HttpGet("{param:guid}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {

            //throw new Exception("Exception ao retornar produto pelo id");
            //string[] teste = null;
            //if (teste.Length > 0)
            //{ }

            var produto = await _context.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProdutoId == id);

            if(produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        //  api/produtos
        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        // api/produtos/1
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Produto produto)
        {

            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if( id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        //  api/produtos/1
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }
    }
}