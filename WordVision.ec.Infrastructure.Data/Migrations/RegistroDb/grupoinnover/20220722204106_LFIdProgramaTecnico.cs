using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class LFIdProgramaTecnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.RenameColumn(
                name: "IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                newName: "IdProgramaTecnico");

            migrationBuilder.RenameIndex(
                name: "IX_LogFrames_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                newName: "IX_LogFrames_IdProgramaTecnico");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.RenameColumn(
                name: "IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames",
                newName: "IdProyectoTecnico");

            migrationBuilder.RenameIndex(
                name: "IX_LogFrames_IdProgramaTecnico",
                schema: "adm",
                table: "LogFrames",
                newName: "IX_LogFrames_IdProyectoTecnico");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
