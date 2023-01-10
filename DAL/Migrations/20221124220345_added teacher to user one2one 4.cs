using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addedteachertouserone2one4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e470201-a197-471c-815d-d8c9f84bc98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "773129e5-806d-4760-9e8a-daa8c8f10ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76fba48-4ea6-4920-8c68-2c7cf87fc4d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "821689a9-37e1-4614-8a17-3d9cbcd5800d", "cf03b079-e495-401a-ae8c-a70581fb55b8", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "275923ab-1f01-439c-9c13-016c00565964", "83c157f6-e304-4fa2-8819-45966ffc9d11", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f016184c-279a-4020-8275-77d208cba1bd", "3bf7d90e-56e6-4cf0-81e7-9eba3a6a1ab4", "Secretary", "SECRETARY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "275923ab-1f01-439c-9c13-016c00565964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "821689a9-37e1-4614-8a17-3d9cbcd5800d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f016184c-279a-4020-8275-77d208cba1bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76fba48-4ea6-4920-8c68-2c7cf87fc4d1", "09630ce0-adcd-4226-aa48-dbd02d1b220b", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "773129e5-806d-4760-9e8a-daa8c8f10ed3", "2214a5ec-302e-4da1-8eeb-e48f26cf55d1", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e470201-a197-471c-815d-d8c9f84bc98b", "010d46d0-910a-4cef-a088-90b6657a3c30", "Secretary", "SECRETARY" });
        }
    }
}
