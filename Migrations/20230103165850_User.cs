using Microsoft.EntityFrameworkCore.Migrations;

namespace virtualReality.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "firstName", "lastName", "password", "phoneNumber", "username" },
                values: new object[] { 1, null, "Nikola", "Valchanov", "nikipass", null, "nikiv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
