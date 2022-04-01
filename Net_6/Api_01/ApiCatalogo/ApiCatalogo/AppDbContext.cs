using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        { }

        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<CategoriaModel>? Categorias { get; set; }
    }
}
