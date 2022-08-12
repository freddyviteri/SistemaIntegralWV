using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class CambiosMarcoLogicoAsignado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_ProgramaTecnicoPorProgramaArea_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramaTecnicoPorProgramaArea",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.RenameTable(
                name: "ProgramaTecnicoPorProgramaArea",
                schema: "indicador",
                newName: "MarcoLogicoAsignado",
                newSchema: "indicador");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdSupervisor",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                newName: "IX_MarcoLogicoAsignado_IdSupervisor");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdResponsable",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                newName: "IX_MarcoLogicoAsignado_IdResponsable");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdProyectoTecnico",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                newName: "IX_MarcoLogicoAsignado_IdProyectoTecnico");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdMarcoLogico",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                newName: "IX_MarcoLogicoAsignado_IdMarcoLogico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcoLogicoAsignado",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarcoLogicoAsignado_Colaboradores_IdResponsable",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                column: "IdResponsable",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarcoLogicoAsignado_Colaboradores_IdSupervisor",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                column: "IdSupervisor",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarcoLogicoAsignado_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                column: "IdMarcoLogico",
                principalSchema: "adm",
                principalTable: "MarcoLogico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarcoLogicoAsignado_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "MarcoLogicoAsignado",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcoLogicoAsignado_Colaboradores_IdResponsable",
                schema: "indicador",
                table: "MarcoLogicoAsignado");

            migrationBuilder.DropForeignKey(
                name: "FK_MarcoLogicoAsignado_Colaboradores_IdSupervisor",
                schema: "indicador",
                table: "MarcoLogicoAsignado");

            migrationBuilder.DropForeignKey(
                name: "FK_MarcoLogicoAsignado_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "MarcoLogicoAsignado");

            migrationBuilder.DropForeignKey(
                name: "FK_MarcoLogicoAsignado_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "MarcoLogicoAsignado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcoLogicoAsignado",
                schema: "indicador",
                table: "MarcoLogicoAsignado");

            migrationBuilder.RenameTable(
                name: "MarcoLogicoAsignado",
                schema: "indicador",
                newName: "ProgramaTecnicoPorProgramaArea",
                newSchema: "indicador");

            migrationBuilder.RenameIndex(
                name: "IX_MarcoLogicoAsignado_IdSupervisor",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdSupervisor");

            migrationBuilder.RenameIndex(
                name: "IX_MarcoLogicoAsignado_IdResponsable",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdResponsable");

            migrationBuilder.RenameIndex(
                name: "IX_MarcoLogicoAsignado_IdProyectoTecnico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdProyectoTecnico");

            migrationBuilder.RenameIndex(
                name: "IX_MarcoLogicoAsignado_IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdMarcoLogico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramaTecnicoPorProgramaArea",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "Id");

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
                name: "FK_ProgramaTecnicoPorProgramaArea_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdMarcoLogico",
                principalSchema: "adm",
                principalTable: "MarcoLogico",
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
    }
}
