using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class sablon19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi");

            migrationBuilder.AddColumn<string>(
                name: "ElementiId",
                table: "Sabloni",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi",
                column: "SablonId",
                principalTable: "Sabloni",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi");

            migrationBuilder.DropColumn(
                name: "ElementiId",
                table: "Sabloni");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi",
                column: "SablonId",
                principalTable: "Sabloni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
