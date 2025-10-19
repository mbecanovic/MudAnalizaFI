using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudAnalizaFI.Migrations
{
    /// <inheritdoc />
    public partial class jebemga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperacionaLista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraPaketa = table.Column<int>(type: "int", nullable: false),
                    DuzinaPaketa = table.Column<double>(type: "float", nullable: false),
                    BrzinaLinijeUMinuti = table.Column<double>(type: "float", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionaLista", x => x.Id);
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
                name: "Sabloni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vreme = table.Column<double>(type: "float", nullable: true),
                    GustinaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kvantitet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabloni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gustine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrednost = table.Column<double>(type: "float", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SablonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gustine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gustine_Sabloni_SablonId",
                        column: x => x.SablonId,
                        principalTable: "Sabloni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Elementi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duzina = table.Column<double>(type: "float", nullable: false),
                    Sirina = table.Column<double>(type: "float", nullable: false),
                    Visina = table.Column<double>(type: "float", nullable: false),
                    Tezina = table.Column<double>(type: "float", nullable: false),
                    Povrsina = table.Column<double>(type: "float", nullable: true),
                    BrRadnika = table.Column<double>(type: "float", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GustinaId = table.Column<int>(type: "int", nullable: false),
                    PaketId = table.Column<int>(type: "int", nullable: false),
                    SablonId = table.Column<int>(type: "int", nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vreme = table.Column<double>(type: "float", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Elementi_Sabloni_SablonId",
                        column: x => x.SablonId,
                        principalTable: "Sabloni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextFieldItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kvartal = table.Column<int>(type: "int", nullable: true),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    RedniBroj = table.Column<int>(type: "int", nullable: true),
                    Vreme = table.Column<double>(type: "float", nullable: true),
                    OperacionaListaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFieldItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextFieldItems_Elementi_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elementi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextFieldItems_OperacionaLista_OperacionaListaId",
                        column: x => x.OperacionaListaId,
                        principalTable: "OperacionaLista",
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

            migrationBuilder.CreateIndex(
                name: "IX_Elementi_SablonId",
                table: "Elementi",
                column: "SablonId");

            migrationBuilder.CreateIndex(
                name: "IX_Gustine_SablonId",
                table: "Gustine",
                column: "SablonId");

            migrationBuilder.CreateIndex(
                name: "IX_TextFieldItems_ElementId",
                table: "TextFieldItems",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_TextFieldItems_OperacionaListaId",
                table: "TextFieldItems",
                column: "OperacionaListaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextFieldItems");

            migrationBuilder.DropTable(
                name: "Elementi");

            migrationBuilder.DropTable(
                name: "OperacionaLista");

            migrationBuilder.DropTable(
                name: "Gustine");

            migrationBuilder.DropTable(
                name: "Paketi");

            migrationBuilder.DropTable(
                name: "Sabloni");
        }
    }
}
