using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddStudentScheduleOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndScheduleRequestEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndScheduleRequestEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndScheduleRequestEntity_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "f09db4e3-59e0-4c8c-a487-fffaf2239e29");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "af6dc53f-f382-4370-83b7-b485714319bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "3cc6a1f2-bdbb-4c95-87e6-84ca497cb59e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "8bd3fa0e-b6a8-41a4-8f4a-76d0190be93e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndScheduleRequestEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "c6d8af79-665a-4f86-8cc0-c7ea4dfa6f08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "ac731399-29c8-445f-aa4b-0e594223a68b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "0d2b6075-5ed6-4aa9-ab4d-96510a903884");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "bd4402f8-e0af-4e33-bd40-45c461ee8eb2");
        }
    }
}
