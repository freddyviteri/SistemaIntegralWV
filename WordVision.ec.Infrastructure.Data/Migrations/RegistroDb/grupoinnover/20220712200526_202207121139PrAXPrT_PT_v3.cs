using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class _202207121139PrAXPrT_PT_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NombreProyecto",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "programaAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProgramaTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdFinanciamiento",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdUbicacion",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "programaAreaId",
                principalSchema: "adm",
                principalTable: "ProgramaAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProgramaTecnicoId",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.AddColumn<int>(
                name: "IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreProyecto",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdUbicacion",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
