using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class _202207121139PrAXPrT_PT_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdTipoProyecto",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyectoTecnicos",
                schema: "adm",
                table: "ProyectoTecnicos");

            migrationBuilder.RenameTable(
                name: "ProyectoTecnicos",
                schema: "adm",
                newName: "ProgramaTecnicos",
                newSchema: "adm");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoTecnicos_IdTipoProyecto",
                schema: "adm",
                table: "ProgramaTecnicos",
                newName: "IX_ProgramaTecnicos_IdTipoProyecto");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoTecnicos_IdEstado",
                schema: "adm",
                table: "ProgramaTecnicos",
                newName: "IX_ProgramaTecnicos_IdEstado");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoProyecto",
                schema: "adm",
                table: "ProgramaTecnicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                schema: "adm",
                table: "ProgramaTecnicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramaTecnicos",
                schema: "adm",
                table: "ProgramaTecnicos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicos_DetalleCatalogos_IdEstado",
                schema: "adm",
                table: "ProgramaTecnicos",
                column: "IdEstado",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicos_DetalleCatalogos_IdTipoProyecto",
                schema: "adm",
                table: "ProgramaTecnicos",
                column: "IdTipoProyecto",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProgramaTecnicoId",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaseProgramaAreas_ProgramaTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicos_DetalleCatalogos_IdEstado",
                schema: "adm",
                table: "ProgramaTecnicos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicos_DetalleCatalogos_IdTipoProyecto",
                schema: "adm",
                table: "ProgramaTecnicos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramaTecnicos",
                schema: "adm",
                table: "ProgramaTecnicos");

            migrationBuilder.RenameTable(
                name: "ProgramaTecnicos",
                schema: "adm",
                newName: "ProyectoTecnicos",
                newSchema: "adm");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicos_IdTipoProyecto",
                schema: "adm",
                table: "ProyectoTecnicos",
                newName: "IX_ProyectoTecnicos_IdTipoProyecto");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicos_IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos",
                newName: "IX_ProyectoTecnicos_IdEstado");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoProyecto",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyectoTecnicos",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FaseProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdEstado",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicos_DetalleCatalogos_IdTipoProyecto",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdTipoProyecto",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
