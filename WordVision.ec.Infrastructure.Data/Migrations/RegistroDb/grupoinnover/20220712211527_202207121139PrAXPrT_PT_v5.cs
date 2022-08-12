using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class _202207121139PrAXPrT_PT_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.RenameColumn(
                name: "programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                newName: "ProyectoTecnicoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_programaAreaId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                newName: "IX_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "adm",
                table: "ProgramaTecnicos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProyectoTecnicos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdProgramaArea = table.Column<int>(type: "int", nullable: false),
                    IdProgramaTecnico = table.Column<int>(type: "int", nullable: false),
                    NombreProyecto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoTecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_ProgramaAreas_IdProgramaArea",
                        column: x => x.IdProgramaArea,
                        principalSchema: "adm",
                        principalTable: "ProgramaAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_ProgramaTecnicos_IdProgramaTecnico",
                        column: x => x.IdProgramaTecnico,
                        principalSchema: "adm",
                        principalTable: "ProgramaTecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdProgramaArea",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdProgramaArea");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdProgramaTecnico",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdProgramaTecnico");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProyectoTecnicoId",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropTable(
                name: "ProyectoTecnicos",
                schema: "adm");

            migrationBuilder.RenameColumn(
                name: "ProyectoTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                newName: "programaAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                newName: "IX_ProyectoTecnicoPorProgramaAreas_programaAreaId");

            migrationBuilder.AddColumn<int>(
                name: "ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "adm",
                table: "ProgramaTecnicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProgramaTecnicoId");

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
                name: "FK_ProyectoTecnicoPorProgramaAreas_ProgramaTecnicos_ProgramaTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProgramaTecnicoId",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
