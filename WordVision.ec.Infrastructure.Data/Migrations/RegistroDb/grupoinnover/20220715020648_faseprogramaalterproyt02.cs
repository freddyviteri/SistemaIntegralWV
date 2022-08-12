using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class faseprogramaalterproyt02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_FaseProgramaAreas_ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropColumn(
                name: "ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "ProyectoTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "ProyectoTecnicoId",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
