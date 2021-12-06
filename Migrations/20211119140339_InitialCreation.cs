using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    documento = table.Column<string>(type: "text", nullable: true),
                    tipoFornecedor = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    cep = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    cidade = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_enderecos_fornecedores_fornecedorId",
                        column: x => x.fornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    img = table.Column<string>(type: "text", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_fornecedores_fornecedorId",
                        column: x => x.fornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_fornecedorId",
                table: "enderecos",
                column: "fornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produtos_fornecedorId",
                table: "produtos",
                column: "fornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "fornecedores");
        }
    }
}
