using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lsoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedFieldsToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DeletedUserId",
                table: "Posts",
                column: "DeletedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_DeletedUserId",
                table: "Posts",
                column: "DeletedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_DeletedUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_DeletedUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");
        }
    }
}
