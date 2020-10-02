using Microsoft.EntityFrameworkCore.Migrations;

namespace final_poject.Migrations
{
    public partial class UpdatedContactMig20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Contacts");
        }
    }
}
