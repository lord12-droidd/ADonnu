using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class connectteachentwithuserent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43db353a-2b49-434e-ae82-62c96cb4ecc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeaa2541-8802-4e9a-8110-c7dfb149dd74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb22d4f4-5b48-41bd-8480-e0920ad71e6e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2dadd377-ab1f-4b84-8257-a2b460f3f531", "96156f16-c972-4834-9369-948d761faecc", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8786f19-479d-48c5-bf5e-4366d38bf783", "1443db7e-b0d8-48a6-8d9f-b8dc3a2fb6d3", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7c534a4-0d28-41f2-8c75-d8f34d5ca288", "10663979-a523-4996-af9e-ef0e95926941", "Secretary", "SECRETARY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dadd377-ab1f-4b84-8257-a2b460f3f531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8786f19-479d-48c5-bf5e-4366d38bf783");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c534a4-0d28-41f2-8c75-d8f34d5ca288");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43db353a-2b49-434e-ae82-62c96cb4ecc5", "497571fa-1cbc-4422-84ed-5e45331f3c61", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aeaa2541-8802-4e9a-8110-c7dfb149dd74", "a280bf2a-fa22-47f4-aeb7-dc0437a23d9c", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb22d4f4-5b48-41bd-8480-e0920ad71e6e", "1479caac-05f1-42a4-af19-aa1df7008fff", "Secretary", "SECRETARY" });
        }
    }
}
