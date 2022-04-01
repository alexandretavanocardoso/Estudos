using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]

        public decimal? Preco { get; set; }
        public decimal? Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore] // ignora essa propriedade no swagger
        public CategoriaModel? Categoria { get; set; }
    }
}
