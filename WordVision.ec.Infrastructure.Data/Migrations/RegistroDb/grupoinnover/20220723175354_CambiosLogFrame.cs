using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class CambiosLogFrame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProgramaTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProgramaTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
