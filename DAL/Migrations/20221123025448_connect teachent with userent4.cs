using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class connectteachentwithuserent4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers");

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
                values: new object[] { "8e89ee06-e337-41ca-87fc-4159dc1a2f77", "1081fab9-b0be-4028-9a7e-6e3d986fa260", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bcb757d-0552-41bc-bb1e-0a408bc4e7d1", "a24c4a8a-16e3-440a-ba2b-8c6072f146db", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eca1d64a-ccf3-4346-bf0d-f80e9e182ebc", "f6117397-6fa2-4658-baae-bbed1864d4cd", "Secretary", "SECRETARY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bcb757d-0552-41bc-bb1e-0a408bc4e7d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e89ee06-e337-41ca-87fc-4159dc1a2f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca1d64a-ccf3-4346-bf0d-f80e9e182ebc");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
