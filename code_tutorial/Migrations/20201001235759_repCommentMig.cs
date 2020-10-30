using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace code_tutorial.Migrations
{
    public partial class repCommentMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RepliedCommentID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RepliedCommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RepliedCommentID",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "RepliedComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepliedComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepliedComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepliedComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepliedComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_ArticleId",
                table: "RepliedComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_CommentId",
                table: "RepliedComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_UserId",
                table: "RepliedComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepliedComments");

            migrationBuilder.AddColumn<int>(
                name: "RepliedCommentID",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RepliedCommentID",
                table: "Comments",
                column: "RepliedCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RepliedCommentID",
                table: "Comments",
                column: "RepliedCommentID",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
