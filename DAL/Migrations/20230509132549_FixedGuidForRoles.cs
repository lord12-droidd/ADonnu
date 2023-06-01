using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FixedGuidForRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "143bec32-6265-4557-8827-7cd5244bcb11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491adb60-b79e-4792-93f3-a258d03e147c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55622eba-fb26-456a-86f4-390f9fd113b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aab4790c-2090-40d6-87c5-7be67d86e607");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8", "8360619a-008d-4230-8827-70063aff8b71", "Student", "STUDENT" },
                    { "b22a30c6-18ce-431f-8b10-dcf4f11b4391", "830a7d06-8352-4606-856e-8db4efd616b5", "Teacher", "TEACHER" },
                    { "16aaa94d-d83d-45f1-9bac-c0a265e99d66", "dc19695a-1a03-4f0d-bb65-bf1206359f87", "Secretary", "SECRETARY" },
                    { "7ba8f3a2-2254-43c1-aa4f-9d953e479781", "5b829d13-5891-498d-81c5-cb67096a59eb", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "143bec32-6265-4557-8827-7cd5244bcb11", "0513f66b-50c6-4f1f-a75d-8ad5d141f773", "Student", "STUDENT" },
                    { "aab4790c-2090-40d6-87c5-7be67d86e607", "bfd91833-8f22-401f-a4c5-a060a6eeafb3", "Teacher", "TEACHER" },
                    { "491adb60-b79e-4792-93f3-a258d03e147c", "77032742-2629-4748-bdd0-c90c95bc8ecc", "Secretary", "SECRETARY" },
                    { "55622eba-fb26-456a-86f4-390f9fd113b7", "26344069-f941-4691-af85-87f6a28016eb", "Admin", "ADMIN" }
                });
        }
    }
}
