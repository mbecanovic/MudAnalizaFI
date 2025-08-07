using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class sablon10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SablonId",
                table: "Elementi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sabloni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabloni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sabloni_Paketi_PaketId",
                        column: x => x.PaketId,
                        principalTable: "Paketi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elementi_SablonId",
                table: "Elementi",
                column: "SablonId");

            migrationBuilder.CreateIndex(
                name: "IX_Sabloni_PaketId",
                table: "Sabloni",
                column: "PaketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi",
                column: "SablonId",
                principalTable: "Sabloni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementi_Sabloni_SablonId",
                table: "Elementi");

            migrationBuilder.DropTable(
                name: "Sabloni");

            migrationBuilder.DropIndex(
                name: "IX_Elementi_SablonId",
                table: "Elementi");

            migrationBuilder.DropColumn(
                name: "SablonId",
                table: "Elementi");
        }
    }
}
