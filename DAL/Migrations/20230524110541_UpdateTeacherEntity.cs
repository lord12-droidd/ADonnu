using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateTeacherEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EducationDegree",
                table: "Teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Teachers",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationDegree",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "3a374edf-2ef3-4066-89fc-3b8e9068acb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "e964afdc-2022-411b-878f-d289f1173245");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "88410169-fb1a-43a4-ba06-f611ec47b369");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "1eeb150a-cf28-45c4-9f1f-ee0811d178af");
        }
    }
}
