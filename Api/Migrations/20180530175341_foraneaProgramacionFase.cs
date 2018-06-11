using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Migrations
{
    public partial class foraneaProgramacionFase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego");

            migrationBuilder.DropColumn(
                name: "GrupoEquipoId",
                table: "ProgramacionJuego");

            migrationBuilder.AlterColumn<int>(
                name: "FaseId",
                table: "ProgramacionJuego",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego",
                column: "FaseId",
                principalTable: "Fase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego");

            migrationBuilder.AlterColumn<int>(
                name: "FaseId",
                table: "ProgramacionJuego",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GrupoEquipoId",
                table: "ProgramacionJuego",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramacionJuego_Fase_FaseId",
                table: "ProgramacionJuego",
                column: "FaseId",
                principalTable: "Fase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
