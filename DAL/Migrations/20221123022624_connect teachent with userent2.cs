using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class connectteachentwithuserent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2a7cb2c4-be82-4976-b104-92f06c914f5c", "6fd4a4b5-b516-49b3-a600-e18a9e3a3ade", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe7e0e94-f150-447f-aac9-832b90d233fc", "768c5c5f-aa3e-4cef-9532-21d1d34c8fcc", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25a7e51f-4452-4014-acbe-6eb843b6113b", "c0a2e889-aebc-4777-b216-cc5a29d492fc", "Secretary", "SECRETARY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25a7e51f-4452-4014-acbe-6eb843b6113b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a7cb2c4-be82-4976-b104-92f06c914f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7e0e94-f150-447f-aac9-832b90d233fc");

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
    }
}
