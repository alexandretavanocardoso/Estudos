using ApiCatalogo.Services;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        private readonly ILogger<CategoriasController> _logger;
        public CategoriasController(AppDbContext contexto, IConfiguration config, ILogger<CategoriasController> logger)
        {
            _context = contexto;
            _configuration = config;

            _logger = logger;
        }

        [HttpGet("autor")]
        public string GetAutor()
        {
            var autor = _configuration["autor"]; 
            var conexao = _configuration["ConnectionStrings:DefaultConnection"];

            return $"Autor : {autor}  Conexao: {conexao}";
        }

        [HttpGet("saudacao")]
        public ActionResult<string> GetSaudacao([FromServices] IService service, string nome)
        {
            _logger.LogInformation("===============================GET api/categorias/saudacao ============================");

            return service.Saudacao(nome);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking()
                .FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            //var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}

