using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class sablon15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sabloni_Paketi_PaketId",
                table: "Sabloni");

            migrationBuilder.DropIndex(
                name: "IX_Sabloni_PaketId",
                table: "Sabloni");

            migrationBuilder.DropColumn(
                name: "PaketId",
                table: "Sabloni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaketId",
                table: "Sabloni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sabloni_PaketId",
                table: "Sabloni",
                column: "PaketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sabloni_Paketi_PaketId",
                table: "Sabloni",
                column: "PaketId",
                principalTable: "Paketi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
