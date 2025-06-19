using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class cetvrtaMigracija0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementi_Gustine_GustinaId",
                table: "Elementi");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementi_Gustine_GustinaId",
                table: "Elementi",
                column: "GustinaId",
                principalTable: "Gustine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementi_Gustine_GustinaId",
                table: "Elementi");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementi_Gustine_GustinaId",
                table: "Elementi",
                column: "GustinaId",
                principalTable: "Gustine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
