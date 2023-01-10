using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addedteachertouserone2one3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20e6d769-e23e-436e-be2f-6b12656b7112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50a7a223-a6d6-4421-986e-5f6cb7e8333c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c58a7ef6-5f81-4c47-8241-e4731fe387d8");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76fba48-4ea6-4920-8c68-2c7cf87fc4d1", "09630ce0-adcd-4226-aa48-dbd02d1b220b", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "773129e5-806d-4760-9e8a-daa8c8f10ed3", "2214a5ec-302e-4da1-8eeb-e48f26cf55d1", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e470201-a197-471c-815d-d8c9f84bc98b", "010d46d0-910a-4cef-a088-90b6657a3c30", "Secretary", "SECRETARY" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserEntityId",
                table: "Teachers",
                column: "UserEntityId",
                unique: true,
                filter: "[UserEntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserEntityId",
                table: "Students",
                column: "UserEntityId",
                unique: true,
                filter: "[UserEntityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserEntityId",
                table: "Students",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserEntityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserEntityId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserEntityId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e470201-a197-471c-815d-d8c9f84bc98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "773129e5-806d-4760-9e8a-daa8c8f10ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76fba48-4ea6-4920-8c68-2c7cf87fc4d1");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c58a7ef6-5f81-4c47-8241-e4731fe387d8", "b1faef6e-b81b-424b-8920-6e351e82701e", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20e6d769-e23e-436e-be2f-6b12656b7112", "f1be3463-689d-4b71-90ab-afbcba5ea77a", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50a7a223-a6d6-4421-986e-5f6cb7e8333c", "89f6e2c1-d609-4cd6-a154-d83d024b14bb", "Secretary", "SECRETARY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
