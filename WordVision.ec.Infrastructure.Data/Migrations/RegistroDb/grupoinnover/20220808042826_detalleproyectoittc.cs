using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class detalleproyectoittc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTs_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdMarcoLogico");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProyectoITTs_MarcoLogico_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdMarcoLogico",
                principalSchema: "adm",
                principalTable: "MarcoLogico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProyectoITTs_MarcoLogico_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProyectoITTs_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropColumn(
                name: "IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs");
        }
    }
}
