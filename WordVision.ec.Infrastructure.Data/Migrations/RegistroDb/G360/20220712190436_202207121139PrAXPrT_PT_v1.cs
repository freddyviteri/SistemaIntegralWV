using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.G360
{
    public partial class _202207121139PrAXPrT_PT_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaAreas_IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas");

            migrationBuilder.DropColumn(
                name: "IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                schema: "indicador",
                table: "FaseProgramaAreas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProgramaTecnicos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaTecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramaTecnicos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogFrameIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    Asignado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoTecnicoPorProgramaAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                        column: x => x.IdLogFrameIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "LogFrameIndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicos_IdEstado",
                schema: "adm",
                table: "ProgramaTecnicos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdLogFrameIndicadorPR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramaTecnicos",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador");

            migrationBuilder.DropColumn(
                name: "Observacion",
                schema: "indicador",
                table: "FaseProgramaAreas");

            migrationBuilder.AddColumn<int>(
                name: "IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAreas_IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas",
                column: "IdProyectoTecnico");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
