using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scan.Migrations
{
    /// <inheritdoc />
    public partial class tentandodenovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Mangas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Mangas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Authors_AuthorId",
                table: "Mangas",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
