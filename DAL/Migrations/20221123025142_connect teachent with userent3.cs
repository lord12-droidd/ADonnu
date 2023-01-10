using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class connectteachentwithuserent3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "1a389aec-531f-4621-afb4-a8ae56831c9a", "b198a1f5-493f-4978-aba3-3d7d4406cdf9", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4b69087-5d70-4c37-b0c6-663a603c9413", "074934a9-809f-4e33-908c-13992dc91383", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3185ed69-892d-42ac-824d-2b4485696d51", "533d967e-4d09-4212-be0a-525078fb2473", "Secretary", "SECRETARY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a389aec-531f-4621-afb4-a8ae56831c9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3185ed69-892d-42ac-824d-2b4485696d51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4b69087-5d70-4c37-b0c6-663a603c9413");

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
        }
    }
}
