using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Migrations
{
    public partial class EstadisticaEquipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiferenciaGoles",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolesAFavor",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolesEnContra",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosEmpatados",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosGanados",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosJugados",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosPerdidos",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "Equipo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiferenciaGoles",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "GolesAFavor",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "GolesEnContra",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "PartidosEmpatados",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "PartidosGanados",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "PartidosJugados",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "PartidosPerdidos",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "Equipo");
        }
    }
}
