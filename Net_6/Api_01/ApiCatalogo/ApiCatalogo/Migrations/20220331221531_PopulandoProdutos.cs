using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulandoProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, IMAGEMURL, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES('Macarrao', 'Comida boa', 'macarrao.jpg', 5.0, 4, now(), 2)");
            migrationBuilder.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, IMAGEMURL, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES('Coca', 'Coca boa', 'coca.jpg', 50, 7, now(), 1)");
            migrationBuilder.Sql("INSERT INTO PRODUTOS(NOME, DESCRICAO, IMAGEMURL, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES('Pudim', 'Pudim bom', 'pudim.jpg', 5.0, 9, now(), 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PRODUTOS");
        }
    }
}
