using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class jebemga1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextFieldItems_Elementi_ElementId",
                table: "TextFieldItems");

            migrationBuilder.AddColumn<int>(
                name: "PodElementId",
                table: "TextFieldItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextFieldItems_PodElementId",
                table: "TextFieldItems",
                column: "PodElementId",
                unique: true,
                filter: "[PodElementId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TextFieldItems_Elementi_ElementId",
                table: "TextFieldItems",
                column: "ElementId",
                principalTable: "Elementi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextFieldItems_Elementi_PodElementId",
                table: "TextFieldItems",
                column: "PodElementId",
                principalTable: "Elementi",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextFieldItems_Elementi_ElementId",
                table: "TextFieldItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TextFieldItems_Elementi_PodElementId",
                table: "TextFieldItems");

            migrationBuilder.DropIndex(
                name: "IX_TextFieldItems_PodElementId",
                table: "TextFieldItems");

            migrationBuilder.DropColumn(
                name: "PodElementId",
                table: "TextFieldItems");

            migrationBuilder.AddForeignKey(
                name: "FK_TextFieldItems_Elementi_ElementId",
                table: "TextFieldItems",
                column: "ElementId",
                principalTable: "Elementi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
