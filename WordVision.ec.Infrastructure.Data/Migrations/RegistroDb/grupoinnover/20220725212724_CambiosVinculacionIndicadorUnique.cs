using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class CambiosVinculacionIndicadorUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores",
                columns: new[] { "IdMarcoLogico", "IdOtroIndicador" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdMarcoLogico");
        }
    }
}
