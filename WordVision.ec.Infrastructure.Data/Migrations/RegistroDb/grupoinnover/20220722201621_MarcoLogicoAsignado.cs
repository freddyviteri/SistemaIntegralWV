using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MarcoLogicoAsignado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropColumn(
                name: "IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropColumn(
                name: "IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.RenameColumn(
                name: "ProyectoTecnicoId",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IdResponsable");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdResponsable");

            migrationBuilder.AddColumn<int>(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdProyectoTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdSupervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_Colaboradores_IdResponsable",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdResponsable",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_Colaboradores_IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdSupervisor",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_Colaboradores_IdResponsable",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_Colaboradores_IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropColumn(
                name: "IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropColumn(
                name: "IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.RenameColumn(
                name: "IdResponsable",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "ProyectoTecnicoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdResponsable",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_ProyectoTecnicoId");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdUbicacion");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdFinanciamiento",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdUbicacion",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "ProyectoTecnicoId",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
