using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class faseprogramaalter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaAreas_IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_FaseProgramaAreas_IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_FaseProgramaAreas_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProgramaArea");

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico");

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaAreas_IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProgramaArea",
                principalSchema: "adm",
                principalTable: "ProgramaAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
