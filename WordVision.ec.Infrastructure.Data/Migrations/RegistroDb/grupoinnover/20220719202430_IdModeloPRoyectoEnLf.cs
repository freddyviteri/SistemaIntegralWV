using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class IdModeloPRoyectoEnLf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdModeloProyecto",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdModeloProyecto",
                schema: "adm",
                table: "LogFrames",
                column: "IdModeloProyecto");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ModeloProyectos_IdModeloProyecto",
                schema: "adm",
                table: "LogFrames",
                column: "IdModeloProyecto",
                principalSchema: "adm",
                principalTable: "ModeloProyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ModeloProyectos_IdModeloProyecto",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdModeloProyecto",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdModeloProyecto",
                schema: "adm",
                table: "LogFrames");
        }
    }
}
