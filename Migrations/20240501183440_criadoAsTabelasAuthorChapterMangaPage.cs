using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scan.Migrations
{
    /// <inheritdoc />
    public partial class criadoAsTabelasAuthorChapterMangaPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Mangas");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Mangas",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "Mangas",
                newName: "RealeseDate");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Mangas",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Mangas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Mangas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_AuthorId",
                table: "Mangas",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_MangaId",
                table: "Chapter",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_ChapterId",
                table: "Page",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Mangas_AuthorId",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Mangas");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Mangas",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "RealeseDate",
                table: "Mangas",
                newName: "PostDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Mangas",
                newName: "Link");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
