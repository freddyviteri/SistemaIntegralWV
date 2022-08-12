using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class programatecnicoporprogramaarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador");

            migrationBuilder.CreateTable(
                name: "ProgramaTecnicoPorProgramaArea",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProyectoTecnicoId = table.Column<int>(type: "int", nullable: true),
                    IdUbicacion = table.Column<int>(type: "int", nullable: true),
                    IdFinanciamiento = table.Column<int>(type: "int", nullable: true),
                    IdLogFrameIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    Asignado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaTecnicoPorProgramaArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdFinanciamiento",
                        column: x => x.IdFinanciamiento,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramaTecnicoPorProgramaArea_DetalleCatalogos_IdUbicacion",
                        column: x => x.IdUbicacion,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramaTecnicoPorProgramaArea_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                        column: x => x.IdLogFrameIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "LogFrameIndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaTecnicoPorProgramaArea_ProyectoTecnicos_ProyectoTecnicoId",
                        column: x => x.ProyectoTecnicoId,
                        principalSchema: "adm",
                        principalTable: "ProyectoTecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdFinanciamiento",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdLogFrameIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdUbicacion",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "ProyectoTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropTable(
                name: "ProgramaTecnicoPorProgramaArea",
                schema: "indicador");

            migrationBuilder.CreateTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asignado = table.Column<bool>(type: "bit", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFinanciamiento = table.Column<int>(type: "int", nullable: true),
                    IdLogFrameIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    IdUbicacion = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProyectoTecnicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoTecnicoPorProgramaAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdFinanciamiento",
                        column: x => x.IdFinanciamiento,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_DetalleCatalogos_IdUbicacion",
                        column: x => x.IdUbicacion,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                        column: x => x.IdLogFrameIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "LogFrameIndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicos_ProyectoTecnicoId",
                        column: x => x.ProyectoTecnicoId,
                        principalSchema: "adm",
                        principalTable: "ProyectoTecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdFinanciamiento",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdLogFrameIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdUbicacion",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_ProyectoTecnicoId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "ProyectoTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProgramaTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProgramaTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
