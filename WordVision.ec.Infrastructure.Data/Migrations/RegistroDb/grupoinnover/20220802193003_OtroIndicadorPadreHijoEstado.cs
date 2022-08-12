using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class OtroIndicadorPadreHijoEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OtroIndicadorPadreHijo_IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_OtroIndicadorPadreHijo_DetalleCatalogos_IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo",
                column: "IdEstado",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtroIndicadorPadreHijo_DetalleCatalogos_IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo");

            migrationBuilder.DropIndex(
                name: "IX_OtroIndicadorPadreHijo_IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                schema: "indicador",
                table: "OtroIndicadorPadreHijo");
        }
    }
}
