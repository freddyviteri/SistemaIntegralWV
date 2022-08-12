using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class RemoveFieldsVinculacionIndicador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanNacionalDesarrollo",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropColumn(
                name: "Riesgos",
                schema: "indicador",
                table: "VinculacionIndicadores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanNacionalDesarrollo",
                schema: "indicador",
                table: "VinculacionIndicadores",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Riesgos",
                schema: "indicador",
                table: "VinculacionIndicadores",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
