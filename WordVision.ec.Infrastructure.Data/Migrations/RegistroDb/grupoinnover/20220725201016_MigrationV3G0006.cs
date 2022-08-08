using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G0006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "EstadoKitCourier",
                schema: "donacion",
                table: "Interaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntregaKit",
                schema: "donacion",
                table: "Interaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroGuiaKit",
                schema: "donacion",
                table: "Interaciones",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoKitCourier",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.DropColumn(
                name: "FechaEntregaKit",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.DropColumn(
                name: "NumeroGuiaKit",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
