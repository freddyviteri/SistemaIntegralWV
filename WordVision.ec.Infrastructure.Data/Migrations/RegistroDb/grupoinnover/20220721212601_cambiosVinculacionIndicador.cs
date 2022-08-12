using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class cambiosVinculacionIndicador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresML_IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropTable(
                name: "DetalleVinculacionIndicador",
                schema: "indicador");

            migrationBuilder.RenameColumn(
                name: "IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IdOtroIndicador");

            migrationBuilder.RenameIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorML",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IX_VinculacionIndicadores_IdOtroIndicador");

            migrationBuilder.AddColumn<int>(
                name: "IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdMarcoLogico");

            migrationBuilder.AddForeignKey(
                name: "FK_VinculacionIndicadores_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdMarcoLogico",
                principalSchema: "adm",
                principalTable: "MarcoLogico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VinculacionIndicadores_OtrosIndicadores_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdOtroIndicador",
                principalSchema: "adm",
                principalTable: "OtrosIndicadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_MarcoLogico_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_OtrosIndicadores_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropIndex(
                name: "IX_VinculacionIndicadores_IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropColumn(
                name: "IdMarcoLogico",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.RenameColumn(
                name: "IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IdIndicadorML");

            migrationBuilder.RenameIndex(
                name: "IX_VinculacionIndicadores_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores",
                newName: "IX_VinculacionIndicadores_IdIndicadorML");

            migrationBuilder.CreateTable(
                name: "DetalleVinculacionIndicador",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOtroIndicador = table.Column<int>(type: "int", nullable: false),
                    IdVinculacionIndicador = table.Column<int>(type: "int", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVinculacionIndicador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVinculacionIndicador_OtrosIndicadores_IdOtroIndicador",
                        column: x => x.IdOtroIndicador,
                        principalSchema: "adm",
                        principalTable: "OtrosIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVinculacionIndicador_VinculacionIndicadores_IdVinculacionIndicador",
                        column: x => x.IdVinculacionIndicador,
                        principalSchema: "indicador",
                        principalTable: "VinculacionIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdOtroIndicador",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdOtroIndicador");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdVinculacionIndicador",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdVinculacionIndicador");

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
    }
}
