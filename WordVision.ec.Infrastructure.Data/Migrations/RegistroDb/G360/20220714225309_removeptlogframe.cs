using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.G360
{
    public partial class removeptlogframe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
