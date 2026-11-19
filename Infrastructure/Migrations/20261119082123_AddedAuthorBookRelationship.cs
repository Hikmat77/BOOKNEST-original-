using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthorBookRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_books_authorid",
                table: "books",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_authorid",
                table: "books",
                column: "authorid",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_authorid",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_authorid",
                table: "books");
        }
    }
}
