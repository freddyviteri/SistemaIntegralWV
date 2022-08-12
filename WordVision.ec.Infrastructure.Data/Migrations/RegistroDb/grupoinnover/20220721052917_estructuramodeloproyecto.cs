using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class estructuramodeloproyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloProyectos_EtapaModeloProyectos_IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos");

            migrationBuilder.DropTable(
                name: "EtapaModeloProyectos",
                schema: "adm");

            migrationBuilder.DropIndex(
                name: "IX_ModeloProyectos_IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos");

            migrationBuilder.DropColumn(
                name: "IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "adm",
                table: "ModeloProyectos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "AccionOperativas",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionOperativas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionOperativas_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etapas",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etapas_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionOperativas_IdEstado",
                schema: "adm",
                table: "AccionOperativas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_IdEstado",
                schema: "adm",
                table: "Etapas",
                column: "IdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionOperativas",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Etapas",
                schema: "adm");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "adm",
                table: "ModeloProyectos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EtapaModeloProyectos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etapa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdAccionOperativa = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaModeloProyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapaModeloProyectos_DetalleCatalogos_IdAccionOperativa",
                        column: x => x.IdAccionOperativa,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapaModeloProyectos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProyectos_IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos",
                column: "IdEtapaModeloProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaModeloProyectos_IdAccionOperativa",
                schema: "adm",
                table: "EtapaModeloProyectos",
                column: "IdAccionOperativa");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaModeloProyectos_IdEstado",
                schema: "adm",
                table: "EtapaModeloProyectos",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloProyectos_EtapaModeloProyectos_IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos",
                column: "IdEtapaModeloProyecto",
                principalSchema: "adm",
                principalTable: "EtapaModeloProyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
