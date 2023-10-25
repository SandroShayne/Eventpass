using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPass1.Migrations
{
    public partial class M22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Eventos_EventoId",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Eventos_EventoId",
                table: "Ingressos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Eventos_EventoId",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Eventos_EventoId",
                table: "Ingressos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
