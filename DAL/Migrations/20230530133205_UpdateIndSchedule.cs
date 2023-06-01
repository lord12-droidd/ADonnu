using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateIndSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AzureAccessPath",
                table: "IndScheduleRequests",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "7517b546-fc73-48a7-864b-bc7f2107312b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "22dd681b-0b9c-430a-aaac-3115593d8d1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "c4a275c3-0c31-4c91-ba5e-795169cbe701");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "cb571cb4-052b-4154-910e-e83a97891d4e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AzureAccessPath",
                table: "IndScheduleRequests");

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
        }
    }
}
