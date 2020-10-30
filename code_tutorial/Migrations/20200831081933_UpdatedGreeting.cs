using Microsoft.EntityFrameworkCore.Migrations;

namespace code_tutorial.Migrations
{
    public partial class UpdatedGreeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Greetings",
                columns: new[] { "Id", "Content", "Header", "Image" },
                values: new object[] { 1, "\"Developer\" olmaq istəyirsiniz amma qarşınızda böyük bir problem var? İngiliscə tam anlamırsınız? Narahat olmağa dəyməz. Artıq proqramlaşdırma sahəsinə aid məqalələri öz ana dilimizdə də tapa biləcəksiniz. Sadəcə aşağıdakı axtarış hissəsindən istədiyiniz məqaləni axtarmağınız kifayət edir.", "Azərbaycanın \"Developer\" portalı", "greeting.svg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Greetings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
