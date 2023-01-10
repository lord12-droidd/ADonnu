using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addedteachertouserone2one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserEntityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserEntityId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserEntityId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b5f59e-184a-40ac-8a6e-2e2e55745b29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23239303-4af7-476b-bacb-0a1188d932e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f70a85f5-63b2-4a98-a6f7-315aab398fa6");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "TeacherEntity");

            migrationBuilder.RenameColumn(
                name: "StudentEntityId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeacherEntityId",
                table: "TeacherEntity",
                newName: "Id");

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
                name: "FK_Students_AspNetUsers_Id",
                table: "Students",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherEntity_AspNetUsers_Id",
                table: "TeacherEntity",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students");

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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherEntityId");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "TeacherEntityId");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05b5f59e-184a-40ac-8a6e-2e2e55745b29", "554e8008-481b-4bec-b197-f6333feb419b", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f70a85f5-63b2-4a98-a6f7-315aab398fa6", "c0c4e107-60c6-40c8-8917-c407773ba52b", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23239303-4af7-476b-bacb-0a1188d932e4", "5cfe3cad-3442-4cb5-bd6a-3d0cb6ce5065", "Secretary", "SECRETARY" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserEntityId",
                table: "Students",
                column: "UserEntityId",
                unique: true,
                filter: "[UserEntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserEntityId",
                table: "Teachers",
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
    }
}
