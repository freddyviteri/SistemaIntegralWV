using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class OtroIndicadorPadreHijo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtroIndicadorPadreHijo",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPadre = table.Column<int>(type: "int", nullable: false),
                    IdHijo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtroIndicadorPadreHijo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtroIndicadorPadreHijo_OtrosIndicadores_IdHijo",
                        column: x => x.IdHijo,
                        principalSchema: "adm",
                        principalTable: "OtrosIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtroIndicadorPadreHijo_OtrosIndicadores_IdPadre",
                        column: x => x.IdPadre,
                        principalSchema: "adm",
                        principalTable: "OtrosIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtroIndicadorPadreHijo_IdHijo",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo",
                column: "IdHijo");

            migrationBuilder.CreateIndex(
                name: "IX_OtroIndicadorPadreHijo_IdPadre_IdHijo",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo",
                columns: new[] { "IdPadre", "IdHijo" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtroIndicadorPadreHijo",
                schema: "indicador");
        }
    }
}
