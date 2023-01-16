using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaocompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao", "Preco" },
                values: new object[] { new Guid("76427e6f-8641-4b44-bd88-06d050f1ecf3"), 1, "Descricao01", "Produto01", 1, 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("76427e6f-8641-4b44-bd88-06d050f1ecf3"));
        }
    }
}
