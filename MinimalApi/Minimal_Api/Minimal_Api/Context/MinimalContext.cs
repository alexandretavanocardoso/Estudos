using Microsoft.EntityFrameworkCore;
using Minimal_Api.Models;

namespace Minimal_Api.Context
{
    public class MinimalContext : DbContext
    {
        public MinimalContext(DbContextOptions<MinimalContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

        // vai se chamado quando contexto for criado
        protected override void OnModelCreating(ModelBuilder mb)
        {
            // API Fluent - configuracao dos modelos das entidades, mais usados em tipos string e decimal

            mb.Entity<Categoria>().HasKey(e => e.CategoriaId);
            mb.Entity<Categoria>().Property(e => e.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Categoria>().Property(e => e.Descricao)
                                  .HasMaxLength(1000)
                                  .IsRequired();

            mb.Entity<Produto>().HasKey(p => p.ProdutoId);

            mb.Entity<Produto>().Property(e => e.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Produto>().Property(e => e.Descricao)
                                  .HasMaxLength(1000)
                                  .IsRequired();

            mb.Entity<Produto>().Property(e => e.Imagem)
                                  .HasMaxLength(3000);

            mb.Entity<Produto>().Property(p => p.Preco).HasPrecision(10, 0);

            // relacionamentos
            mb.Entity<Produto>() //produto tem relacionamento com categoria
              .HasOne<Categoria>(c => c.Categoria) // pega o lado UM
              .WithMany(p => p.Produtos) // pega o lado MUITOS
              .HasForeignKey(c => c.CategoriaId); // foreign key
        }
    }
}
