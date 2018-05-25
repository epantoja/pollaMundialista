using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BanderaUrl = table.Column<string>(maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    PublicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoEquipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Color = table.Column<string>(maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEquipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Estado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CodUsuario = table.Column<string>(maxLength: 150, nullable: false),
                    ContrasenaHash = table.Column<byte[]>(nullable: false),
                    ContrasenaSalt = table.Column<byte[]>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 240, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramacionJuego",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EquipoAId = table.Column<int>(nullable: false),
                    EquipoBId = table.Column<int>(nullable: false),
                    FechaJuego = table.Column<DateTime>(nullable: false),
                    GrupoEquipoId = table.Column<int>(nullable: false),
                    MarcadorA = table.Column<int>(nullable: false),
                    MarcadorB = table.Column<int>(nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramacionJuego", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramacionJuego_Equipo_EquipoAId",
                        column: x => x.EquipoAId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramacionJuego_Equipo_EquipoBId",
                        column: x => x.EquipoBId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramacionJuego_GrupoEquipo_GrupoEquipoId",
                        column: x => x.GrupoEquipoId,
                        principalTable: "GrupoEquipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioGrupoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Estado = table.Column<bool>(nullable: false),
                    GrupoUsuarioId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioGrupoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioGrupoUsuario_GrupoUsuario_GrupoUsuarioId",
                        column: x => x.GrupoUsuarioId,
                        principalTable: "GrupoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioGrupoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ProgramacionJuego_EquipoAId",
                table: "ProgramacionJuego",
                column: "EquipoAId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramacionJuego_EquipoBId",
                table: "ProgramacionJuego",
                column: "EquipoBId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupoUsuario_GrupoUsuarioId",
                table: "UsuarioGrupoUsuario",
                column: "GrupoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupoUsuario_UsuarioId",
                table: "UsuarioGrupoUsuario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultadosJuego");

            migrationBuilder.DropTable(
                name: "UsuarioGrupoUsuario");

            migrationBuilder.DropTable(
                name: "ProgramacionJuego");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "GrupoEquipo");
        }
    }
}
