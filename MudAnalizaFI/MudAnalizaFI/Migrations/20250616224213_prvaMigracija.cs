using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class prvaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gustine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrednost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gustine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paketi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraPaketa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duzina = table.Column<double>(type: "float", nullable: false),
                    Sirina = table.Column<double>(type: "float", nullable: false),
                    Visina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paketi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elementi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duzina = table.Column<double>(type: "float", nullable: false),
                    Sirina = table.Column<double>(type: "float", nullable: false),
                    Visina = table.Column<double>(type: "float", nullable: false),
                    GustinaId = table.Column<int>(type: "int", nullable: false),
                    PaketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elementi_Gustine_GustinaId",
                        column: x => x.GustinaId,
                        principalTable: "Gustine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elementi_Paketi_PaketId",
                        column: x => x.PaketId,
                        principalTable: "Paketi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elementi_GustinaId",
                table: "Elementi",
                column: "GustinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elementi_PaketId",
                table: "Elementi",
                column: "PaketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elementi");

            migrationBuilder.DropTable(
                name: "Gustine");

            migrationBuilder.DropTable(
                name: "Paketi");
        }
    }
}
