using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddStudentScheduleOneToOneWithDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndScheduleRequestEntity_Students_Id",
                table: "IndScheduleRequestEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndScheduleRequestEntity",
                table: "IndScheduleRequestEntity");

            migrationBuilder.RenameTable(
                name: "IndScheduleRequestEntity",
                newName: "IndScheduleRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndScheduleRequests",
                table: "IndScheduleRequests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "d601eb01-122a-4ebf-a74d-5a728eaa9527");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "d306e5c3-f5d6-4992-aa4c-7fcf33f59764");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "4b2ba766-81e9-45ca-a191-1bf11b4cc584");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "d1e2f27e-8d48-47e8-b3aa-cb4c8f426c29");

            migrationBuilder.AddForeignKey(
                name: "FK_IndScheduleRequests_Students_Id",
                table: "IndScheduleRequests",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndScheduleRequests_Students_Id",
                table: "IndScheduleRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndScheduleRequests",
                table: "IndScheduleRequests");

            migrationBuilder.RenameTable(
                name: "IndScheduleRequests",
                newName: "IndScheduleRequestEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndScheduleRequestEntity",
                table: "IndScheduleRequestEntity",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_IndScheduleRequestEntity_Students_Id",
                table: "IndScheduleRequestEntity",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
