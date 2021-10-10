using Microsoft.EntityFrameworkCore.Migrations;

namespace LegalAdvice.Persistence.Migrations
{
    public partial class UpdateCommentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comment",
                newName: "Id");
        }
    }
}
