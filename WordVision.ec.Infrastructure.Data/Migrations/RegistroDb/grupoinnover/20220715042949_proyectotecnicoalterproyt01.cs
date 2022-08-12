using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class proyectotecnicoalterproyt01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdUbicacion");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdFinanciamiento",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdUbicacion",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicos_IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropColumn(
                name: "IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropColumn(
                name: "IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos");
        }
    }
}
