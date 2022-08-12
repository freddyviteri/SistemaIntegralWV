using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class revertIdRubro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdRubro",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdRubro",
                schema: "adm",
                table: "LogFrames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRubro",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdRubro",
                schema: "adm",
                table: "LogFrames",
                column: "IdRubro");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "LogFrames",
                column: "IdRubro",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
