using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioCient.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Criado = table.Column<DateTime>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: true),
                    Excluido = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Telefone = table.Column<string>(maxLength: 15, nullable: true),
                    InstituicaoApoio = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
