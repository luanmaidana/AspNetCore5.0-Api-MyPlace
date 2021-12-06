using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class tableMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_fornecedores_fornecedorId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_fornecedores_fornecedorId",
                table: "produtos");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "produtos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "img",
                table: "produtos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produtos",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "fornecedores",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "documento",
                table: "fornecedores",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "numero",
                table: "enderecos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "enderecos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "enderecos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "complemento",
                table: "enderecos",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "enderecos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "enderecos",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bairro",
                table: "enderecos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "img",
                table: "produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "fornecedores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "documento",
                table: "fornecedores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "numero",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "complemento",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AlterColumn<string>(
                name: "bairro",
                table: "enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

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
