using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Migrations
{
    public partial class cambioModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramacionJuego_GrupoEquipo_GrupoEquipoId",
                table: "ProgramacionJuego");

            migrationBuilder.DropTable(
                name: "GrupoEquipo");

            migrationBuilder.DropTable(
                name: "ResultadosJuego");

            migrationBuilder.DropIndex(
                name: "IX_ProgramacionJuego_GrupoEquipoId",
                table: "ProgramacionJuego");

            migrationBuilder.AddColumn<int>(
                name: "FaseId",
                table: "ProgramacionJuego",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Apuesta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarcadoB = table.Column<int>(nullable: false),
                    MarcadorA = table.Column<int>(nullable: false),
                    ProgramacionJuegoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apuesta_ProgramacionJuego_ProgramacionJuegoId",
                        column: x => x.ProgramacionJuegoId,
                        principalTable: "ProgramacionJuego",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuesta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Color = table.Column<string>(maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramacionJuego_FaseId",
                table: "ProgramacionJuego",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuesta_ProgramacionJuegoId",
                table: "Apuesta",
                column: "ProgramacionJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuesta_UsuarioId",
                table: "Apuesta",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego",
                column: "FaseId",
                principalTable: "Fase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego");

            migrationBuilder.DropTable(
                name: "Apuesta");

            migrationBuilder.DropTable(
                name: "Fase");

            migrationBuilder.DropIndex(
                name: "IX_ProgramacionJuego_FaseId",
                table: "ProgramacionJuego");

            migrationBuilder.DropColumn(
                name: "FaseId",
                table: "ProgramacionJuego");

            migrationBuilder.CreateTable(
                name: "GrupoEquipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Color = table.Column<string>(maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEquipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultadosJuego",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarcadoB = table.Column<int>(nullable: false),
                    MarcadorA = table.Column<int>(nullable: false),
                    ProgramacionJuegoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosJuego", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosJuego_ProgramacionJuego_ProgramacionJuegoId",
                        column: x => x.ProgramacionJuegoId,
                        principalTable: "ProgramacionJuego",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultadosJuego_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramacionJuego_GrupoEquipoId",
                table: "ProgramacionJuego",
                column: "GrupoEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosJuego_ProgramacionJuegoId",
                table: "ResultadosJuego",
                column: "ProgramacionJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosJuego_UsuarioId",
                table: "ResultadosJuego",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramacionJuego_GrupoEquipo_GrupoEquipoId",
                table: "ProgramacionJuego",
                column: "GrupoEquipoId",
                principalTable: "GrupoEquipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
