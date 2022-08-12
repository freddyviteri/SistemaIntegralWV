using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class proyectoitt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProyectoITTs_MarcoLogico_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.RenameColumn(
                name: "IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                newName: "IdMarcoLogicoAsignado");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleProyectoITTs_IdMarcoLogico",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                newName: "IX_DetalleProyectoITTs_IdMarcoLogicoAsignado");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProyectoITTs_MarcoLogicoAsignado_IdMarcoLogicoAsignado",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdMarcoLogicoAsignado",
                principalSchema: "indicador",
                principalTable: "MarcoLogicoAsignado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProyectoITTs_MarcoLogicoAsignado_IdMarcoLogicoAsignado",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.RenameColumn(
                name: "IdMarcoLogicoAsignado",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                newName: "IdMarcoLogico");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleProyectoITTs_IdMarcoLogicoAsignado",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                newName: "IX_DetalleProyectoITTs_IdMarcoLogico");

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
    }
}
