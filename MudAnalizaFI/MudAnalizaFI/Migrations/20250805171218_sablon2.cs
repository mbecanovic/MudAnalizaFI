using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class sablon2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GustinaId",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Kvantitet",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SablonId",
                table: "Gustine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gustine_SablonId",
                table: "Gustine",
                column: "SablonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gustine_Sabloni_SablonId",
                table: "Gustine",
                column: "SablonId",
                principalTable: "Sabloni",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gustine_Sabloni_SablonId",
                table: "Gustine");

            migrationBuilder.DropIndex(
                name: "IX_Gustine_SablonId",
                table: "Gustine");

            migrationBuilder.DropColumn(
                name: "GustinaId",
                table: "Sabloni");

            migrationBuilder.DropColumn(
                name: "Kod",
                table: "Sabloni");

            migrationBuilder.DropColumn(
                name: "Kvantitet",
                table: "Sabloni");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Sabloni");

            migrationBuilder.DropColumn(
                name: "SablonId",
                table: "Gustine");
        }
    }
}
