using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scan.Migrations
{
    /// <inheritdoc />
    public partial class crieiTabelaGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaGenero",
                columns: table => new
                {
                    GendersId = table.Column<int>(type: "int", nullable: false),
                    MangasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenero", x => new { x.GendersId, x.MangasId });
                    table.ForeignKey(
                        name: "FK_MangaGenero_Gender_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenero_Mangas_MangasId",
                        column: x => x.MangasId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenero_MangasId",
                table: "MangaGenero",
                column: "MangasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaGenero");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
