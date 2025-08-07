using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class sablon21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Sabloni");

            migrationBuilder.AddColumn<int>(
                name: "Vreme",
                table: "Sabloni",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "Sabloni");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
