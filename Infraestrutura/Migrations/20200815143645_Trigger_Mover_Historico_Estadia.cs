using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Trigger_Mover_Historico_Estadia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            CREATE TRIGGER Mover_Historico
            AFTER UPDATE
            ON Estadia FOR EACH ROW
            BEGIN
                INSERT INTO Historico_Estadia (Id, CarroId, Entrada, Saida, Valor)
                SELECT Id, CarroId, Entrada, Saida, Valor
                FROM Estadia
                WHERE Saida IS NOT NULL;

            END; ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
