using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedSubjectsToStodents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38ee0cc1-8adb-49c8-a88d-3bca657fa15c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c5071a-03f6-47fd-b018-b926e75dd18d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935334ff-28d3-40a5-a1f3-3468608e08c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947a7934-4ca3-4b6d-84a3-f27b03daccf9");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Subjects");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64c5071a-03f6-47fd-b018-b926e75dd18d", "121a8ac3-9004-45c6-a531-9db3755d56c3", "Student", "STUDENT" },
                    { "38ee0cc1-8adb-49c8-a88d-3bca657fa15c", "73722c1a-80ab-4231-b07c-06d530195955", "Teacher", "TEACHER" },
                    { "935334ff-28d3-40a5-a1f3-3468608e08c6", "14c3e2bd-e6ce-48d6-b062-7931abeb337a", "Secretary", "SECRETARY" },
                    { "947a7934-4ca3-4b6d-84a3-f27b03daccf9", "0e9bed90-3b5a-4f16-b2f1-f83ed853e98c", "Admin", "ADMIN" }
                });
        }
    }
}
