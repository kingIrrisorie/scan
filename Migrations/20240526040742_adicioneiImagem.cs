using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scan.Migrations
{
    /// <inheritdoc />
    public partial class adicioneiImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Mangas");
        }
    }
}
