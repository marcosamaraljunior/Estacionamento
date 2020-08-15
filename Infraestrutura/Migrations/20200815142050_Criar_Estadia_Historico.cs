using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Criar_Estadia_Historico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE TABLE Historico_Estadia (Id varbinary(16) NOT NULL, CarroId varbinary(16) NOT NULL, Entrada datetime NOT NULL, Saida datetime NOT NULL, Valor double NOT NULL)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Estadia");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
            name: "Historico_Estadia");
        }
    }
}
