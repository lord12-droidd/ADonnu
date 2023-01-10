using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addedteachertouserone2one2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherEntity_AspNetUsers_Id",
                table: "TeacherEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherEntity",
                table: "TeacherEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2694d64f-a2a9-409e-a223-10038f246adc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26e7ca16-710e-4104-9cea-e45f55e4fb50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a807372-db1e-407c-817e-c7e213a34970");

            migrationBuilder.RenameTable(
                name: "TeacherEntity",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
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

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "TeacherEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherEntity",
                table: "TeacherEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2694d64f-a2a9-409e-a223-10038f246adc", "27a2608c-cbaf-434b-ae3c-ec7665a80601", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a807372-db1e-407c-817e-c7e213a34970", "e9638d3d-d319-46f2-8c58-9f0587619855", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26e7ca16-710e-4104-9cea-e45f55e4fb50", "4d0b27f2-8a4c-4d52-bc37-bedd43d5507a", "Secretary", "SECRETARY" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEntity_AspNetUsers_Id",
                table: "TeacherEntity",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
