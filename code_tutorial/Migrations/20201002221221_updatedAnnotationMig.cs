using Microsoft.EntityFrameworkCore.Migrations;

namespace code_tutorial.Migrations
{
    public partial class updatedAnnotationMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Greetings",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Greetings",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }
    }
}
