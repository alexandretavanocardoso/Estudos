using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulandoCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('Bebida', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('Comida', 'Comida.jpg')");
            migrationBuilder.Sql("INSERT INTO CATEGORIAS(NOME, IMAGEMURL) VALUES('Sobremesa', 'Sobremesa.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CATEGORIAS");
        }
    }
}
