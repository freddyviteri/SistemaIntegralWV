using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class detalleproyectoitt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoITTs_LogFrames_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoITTs_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.DropColumn(
                name: "IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoITTs_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdLogFrameOutCome");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoITTs_LogFrames_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdLogFrameOutCome",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
