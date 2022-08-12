using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class pittnewtabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleProyectoITTGouls",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMarcoLogicoAsignado = table.Column<int>(type: "int", nullable: false),
                    IdProyectoITT = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProyectoITTGouls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleProyectoITTGouls_MarcoLogicoAsignado_IdMarcoLogicoAsignado",
                        column: x => x.IdMarcoLogicoAsignado,
                        principalSchema: "indicador",
                        principalTable: "MarcoLogicoAsignado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProyectoITTGouls_ProyectoITTs_IdProyectoITT",
                        column: x => x.IdProyectoITT,
                        principalSchema: "planifica",
                        principalTable: "ProyectoITTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTGouls_IdMarcoLogicoAsignado",
                schema: "planifica",
                table: "DetalleProyectoITTGouls",
                column: "IdMarcoLogicoAsignado");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTGouls_IdProyectoITT",
                schema: "planifica",
                table: "DetalleProyectoITTGouls",
                column: "IdProyectoITT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProyectoITTGouls",
                schema: "planifica");
        }
    }
}
