using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class create121userteachuserstud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_Id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "StudentEntitySubjectEntity");

            migrationBuilder.DropTable(
                name: "StudentEntityTeacherEntity");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090532e0-4440-445f-877c-6fe096514d64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16d75821-2ba3-4f1b-a24a-b5e535f2bacc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4211d4a-b491-43ca-b499-3a3b8a9bd23a");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Teachers",
                newName: "UserEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherEntityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentEntityId");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_UserEntityId",
                table: "Teachers",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Teachers",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "TeacherEntityId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentEntityId",
                table: "Students",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "StudentEntitySubjectEntity",
                columns: table => new
                {
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEntitySubjectEntity", x => new { x.StudentsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_StudentEntitySubjectEntity_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEntitySubjectEntity_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEntityTeacherEntity",
                columns: table => new
                {
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeachersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEntityTeacherEntity", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudentEntityTeacherEntity_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEntityTeacherEntity_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "090532e0-4440-445f-877c-6fe096514d64", "939a198f-0de0-427d-8f46-da381b52e0c9", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4211d4a-b491-43ca-b499-3a3b8a9bd23a", "3e2a7224-e762-4e27-b83d-afc3441dbd1b", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16d75821-2ba3-4f1b-a24a-b5e535f2bacc", "8b278045-5bc9-4d85-a005-34f9eb443477", "Secretary", "SECRETARY" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEntitySubjectEntity_SubjectsId",
                table: "StudentEntitySubjectEntity",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEntityTeacherEntity_TeachersId",
                table: "StudentEntityTeacherEntity",
                column: "TeachersId");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
