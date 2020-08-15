using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Criar_Tabela_Historico_Estadia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historico_Estadia",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CarroId = table.Column<byte[]>(nullable: true),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Saida = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico_Estadia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historico_Estadia_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Estadia_CarroId",
                table: "Historico_Estadia",
                column: "CarroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historico_Estadia");
        }
    }
}
