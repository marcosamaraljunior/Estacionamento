using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Estrutura_Tabela_Carro_E_Estadia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Modelo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Placa = table.Column<string>(nullable: true),
                    Tamanho = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estadia",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CarroId = table.Column<byte[]>(nullable: true),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Saida = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estadia_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estadia_CarroId",
                table: "Estadia",
                column: "CarroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estadia");

            migrationBuilder.DropTable(
                name: "Carro");
        }
    }
}
