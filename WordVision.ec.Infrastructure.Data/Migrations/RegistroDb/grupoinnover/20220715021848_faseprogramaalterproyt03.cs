using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class faseprogramaalterproyt03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico");

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_FaseProgramaAreas_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");
        }
    }
}
