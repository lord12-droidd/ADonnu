using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addedteachertouserone2one5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers");

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
                values: new object[] { "1064c62d-cd37-41fd-a7f7-f65e2aa80c57", "abf5c130-c01a-4ee4-aca0-f5c337ba940a", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7eac08c-4e59-44c6-8eec-7f0c1d48c771", "cfdecea4-1fe1-4107-bd89-7ccf3f5ca183", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaeeae22-53da-4977-9459-5ae416ac0d10", "d2db89ba-504c-4467-82ca-f7b1abbd32f8", "Secretary", "SECRETARY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1064c62d-cd37-41fd-a7f7-f65e2aa80c57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7eac08c-4e59-44c6-8eec-7f0c1d48c771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaeeae22-53da-4977-9459-5ae416ac0d10");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
