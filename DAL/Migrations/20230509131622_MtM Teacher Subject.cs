using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MtMTeacherSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0556c8a9-6f83-4186-a302-df065a70c2ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57992d96-ea5a-4bd9-9456-031f7f9405d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b7058b3-762d-43cb-8c92-c00349f4941c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9498a785-05d6-4343-b57e-35e6101e1850");

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.TeacherId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherSubjects");

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
                    { "57992d96-ea5a-4bd9-9456-031f7f9405d7", "4768080f-f92a-4361-8c5c-f2a23bb15cae", "Student", "STUDENT" },
                    { "0556c8a9-6f83-4186-a302-df065a70c2ff", "7986c21e-449c-4c5a-9957-05bbd582ca7e", "Teacher", "TEACHER" },
                    { "5b7058b3-762d-43cb-8c92-c00349f4941c", "d92b3ce4-d2c7-4de5-b17b-5c508453ad54", "Secretary", "SECRETARY" },
                    { "9498a785-05d6-4343-b57e-35e6101e1850", "796071d7-f884-475c-af72-dcceb2d86aca", "Admin", "ADMIN" }
                });
        }
    }
}
