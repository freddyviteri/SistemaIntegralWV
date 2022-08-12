using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class detalleproyectoittb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProyectoITTs_LogFrames_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProyectoITTs_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropColumn(
                name: "IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTs_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdLogFrame");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProyectoITTs_LogFrames_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdLogFrame",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
