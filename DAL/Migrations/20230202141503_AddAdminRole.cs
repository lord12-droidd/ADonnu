using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6727d188-46db-43a8-8e18-2d4462f81dda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62ec11b-4098-4b21-a36b-938fda46b182");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0cd6721-3a40-4f39-81db-c2eb41c6efc5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64c5071a-03f6-47fd-b018-b926e75dd18d", "121a8ac3-9004-45c6-a531-9db3755d56c3", "Student", "STUDENT" },
                    { "38ee0cc1-8adb-49c8-a88d-3bca657fa15c", "73722c1a-80ab-4231-b07c-06d530195955", "Teacher", "TEACHER" },
                    { "935334ff-28d3-40a5-a1f3-3468608e08c6", "14c3e2bd-e6ce-48d6-b062-7931abeb337a", "Secretary", "SECRETARY" },
                    { "947a7934-4ca3-4b6d-84a3-f27b03daccf9", "0e9bed90-3b5a-4f16-b2f1-f83ed853e98c", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38ee0cc1-8adb-49c8-a88d-3bca657fa15c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c5071a-03f6-47fd-b018-b926e75dd18d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935334ff-28d3-40a5-a1f3-3468608e08c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947a7934-4ca3-4b6d-84a3-f27b03daccf9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a62ec11b-4098-4b21-a36b-938fda46b182", "3af995c9-4d1b-4d8f-bfee-d060bd9766a7", "Student", "STUDENT" },
                    { "6727d188-46db-43a8-8e18-2d4462f81dda", "35dc1542-bb4b-4455-9090-d5047706f877", "Teacher", "TEACHER" },
                    { "e0cd6721-3a40-4f39-81db-c2eb41c6efc5", "bc0feb12-9947-4523-99c1-4029ece0495d", "Secretary", "SECRETARY" }
                });
        }
    }
}
