using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class marcoLogico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "IndicadoresPR",
                schema: "adm");

            migrationBuilder.RenameColumn(
                name: "IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IdIndicadorML");

            migrationBuilder.RenameIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IX_VinculacionIndicadores_IdIndicadorML");

            migrationBuilder.RenameColumn(
                name: "IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IdMarcoLogico");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdMarcoLogico");

            migrationBuilder.CreateTable(
                name: "IndicadoresML",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Asunciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MedioVerificacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Poblacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CWB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InclucionRC = table.Column<bool>(type: "bit", nullable: false),
                    IncluyeAdvovacy = table.Column<bool>(type: "bit", nullable: false),
                    IdTarget = table.Column<int>(type: "int", nullable: false),
                    IdFrecuencia = table.Column<int>(type: "int", nullable: false),
                    IdTipoMedida = table.Column<int>(type: "int", nullable: false),
                    IdActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresML", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadoresML_ActorParticipantes_IdActorParticipante",
                        column: x => x.IdActorParticipante,
                        principalSchema: "adm",
                        principalTable: "ActorParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresML_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresML_DetalleCatalogos_IdFrecuencia",
                        column: x => x.IdFrecuencia,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresML_DetalleCatalogos_IdTarget",
                        column: x => x.IdTarget,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresML_DetalleCatalogos_IdTipoMedida",
                        column: x => x.IdTipoMedida,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MarcoLogico",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogFrame = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorML = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcoLogico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarcoLogico_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcoLogico_IndicadoresML_IdIndicadorML",
                        column: x => x.IdIndicadorML,
                        principalSchema: "adm",
                        principalTable: "IndicadoresML",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MarcoLogico_LogFrames_IdLogFrame",
                        column: x => x.IdLogFrame,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdActorParticipante",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdActorParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdEstado",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdFrecuencia",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdFrecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdTarget",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdTarget");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdTipoMedida",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdTipoMedida");

            migrationBuilder.CreateIndex(
                name: "IX_MarcoLogico_IdEstado",
                schema: "adm",
                table: "MarcoLogico",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_MarcoLogico_IdIndicadorML",
                schema: "adm",
                table: "MarcoLogico",
                column: "IdIndicadorML");

            migrationBuilder.CreateIndex(
                name: "IX_MarcoLogico_IdLogFrame",
                schema: "adm",
                table: "MarcoLogico",
                column: "IdLogFrame");

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
                name: "FK_VinculacionIndicadores_IndicadoresML_IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdIndicadorML",
                principalSchema: "adm",
                principalTable: "IndicadoresML",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea");

            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresML_IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropTable(
                name: "MarcoLogico",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "IndicadoresML",
                schema: "adm");

            migrationBuilder.RenameColumn(
                name: "IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IdIndicadorPR");

            migrationBuilder.RenameIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IX_VinculacionIndicadores_IdIndicadorPR");

            migrationBuilder.RenameColumn(
                name: "IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IdLogFrameIndicadorPR");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaTecnicoPorProgramaArea_IdMarcoLogico",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                newName: "IX_ProgramaTecnicoPorProgramaArea_IdLogFrameIndicadorPR");

            migrationBuilder.CreateTable(
                name: "IndicadoresPR",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asunciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CWB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdFrecuencia = table.Column<int>(type: "int", nullable: false),
                    IdTarget = table.Column<int>(type: "int", nullable: false),
                    IdTipoMedida = table.Column<int>(type: "int", nullable: false),
                    InclucionRC = table.Column<bool>(type: "bit", nullable: false),
                    IncluyeAdvovacy = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedioVerificacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Poblacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_ActorParticipantes_IdActorParticipante",
                        column: x => x.IdActorParticipante,
                        principalSchema: "adm",
                        principalTable: "ActorParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdFrecuencia",
                        column: x => x.IdFrecuencia,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdTarget",
                        column: x => x.IdTarget,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdTipoMedida",
                        column: x => x.IdTipoMedida,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    IdLogFrame = table.Column<int>(type: "int", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrameIndicadoresPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_IndicadoresPR_IdIndicadorPR",
                        column: x => x.IdIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "IndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_LogFrames_IdLogFrame",
                        column: x => x.IdLogFrame,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdActorParticipante",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdActorParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdEstado",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdFrecuencia",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdFrecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdTarget",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdTarget");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdTipoMedida",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdTipoMedida");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdEstado",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdLogFrame");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaTecnicoPorProgramaArea_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProgramaTecnicoPorProgramaArea",
                column: "IdLogFrameIndicadorPR",
                principalSchema: "adm",
                principalTable: "LogFrameIndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
