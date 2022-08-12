using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class indicadorMLaddIdAreaCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadoresML_DetalleCatalogos_AreaId",
                schema: "adm",
                table: "IndicadoresML");

            migrationBuilder.DropIndex(
                name: "IX_IndicadoresML_AreaId",
                schema: "adm",
                table: "IndicadoresML");

            migrationBuilder.DropColumn(
                name: "AreaId",
                schema: "adm",
                table: "IndicadoresML");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_IdArea",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdArea");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadoresML_DetalleCatalogos_IdArea",
                schema: "adm",
                table: "IndicadoresML",
                column: "IdArea",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadoresML_DetalleCatalogos_IdArea",
                schema: "adm",
                table: "IndicadoresML");

            migrationBuilder.DropIndex(
                name: "IX_IndicadoresML_IdArea",
                schema: "adm",
                table: "IndicadoresML");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                schema: "adm",
                table: "IndicadoresML",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresML_AreaId",
                schema: "adm",
                table: "IndicadoresML",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadoresML_DetalleCatalogos_AreaId",
                schema: "adm",
                table: "IndicadoresML",
                column: "AreaId",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
