using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace code_tutorial.Migrations
{
    public partial class removedSubjectMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditedArticles");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Subjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EditedSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    EditedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditedSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditedSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditedSubjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemovedSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemovedSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemovedSubjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditedSubjects_SubjectId",
                table: "EditedSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EditedSubjects_UserId",
                table: "EditedSubjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedSubjects_SubjectId",
                table: "RemovedSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedSubjects_UserId",
                table: "RemovedSubjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditedSubjects");

            migrationBuilder.DropTable(
                name: "RemovedSubjects");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "EditedArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditedArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditedArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditedArticles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditedArticles_ArticleId",
                table: "EditedArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_EditedArticles_UserId",
                table: "EditedArticles",
                column: "UserId");
        }
    }
}
