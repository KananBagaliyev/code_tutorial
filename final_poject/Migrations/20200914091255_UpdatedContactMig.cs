using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace final_poject.Migrations
{
    public partial class UpdatedContactMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SendingDate",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isRead",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendingDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "isRead",
                table: "Contacts");
        }
    }
}
