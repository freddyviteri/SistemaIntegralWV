using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBajaCartera",
                schema: "donacion",
                table: "Interaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotivoBajaCartera",
                schema: "donacion",
                table: "Interaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaBajaCartera",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.DropColumn(
                name: "MotivoBajaCartera",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
