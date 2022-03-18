using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class UpdateDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_fornecedores_fornecedorId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_fornecedores_fornecedorId",
                table: "produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_fornecedores_fornecedorId",
                table: "enderecos",
                column: "fornecedorId",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_fornecedores_fornecedorId",
                table: "produtos",
                column: "fornecedorId",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_fornecedores_fornecedorId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_fornecedores_fornecedorId",
                table: "produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_fornecedores_fornecedorId",
                table: "enderecos",
                column: "fornecedorId",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_fornecedores_fornecedorId",
                table: "produtos",
                column: "fornecedorId",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
