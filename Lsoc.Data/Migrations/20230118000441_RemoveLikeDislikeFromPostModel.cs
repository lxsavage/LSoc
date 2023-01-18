using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lsoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLikeDislikeFromPostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
