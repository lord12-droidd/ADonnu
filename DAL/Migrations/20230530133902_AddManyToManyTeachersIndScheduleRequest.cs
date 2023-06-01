using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddManyToManyTeachersIndScheduleRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndScheduleRequestTeachers",
                columns: table => new
                {
                    IndScheduleRequestId = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndScheduleRequestTeachers", x => new { x.IndScheduleRequestId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_IndScheduleRequestTeachers_IndScheduleRequests_IndScheduleR~",
                        column: x => x.IndScheduleRequestId,
                        principalTable: "IndScheduleRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndScheduleRequestTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                column: "ConcurrencyStamp",
                value: "53d456d5-a854-4da3-8645-0c0746cc8d40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                column: "ConcurrencyStamp",
                value: "f37212a1-c82d-492c-b9b9-8e1cb0fe4738");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                column: "ConcurrencyStamp",
                value: "bc096358-3e67-4f71-a8c7-b47e0bc5c040");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                column: "ConcurrencyStamp",
                value: "a41ef9ca-2a49-4235-be5d-0865f2d92896");

            migrationBuilder.CreateIndex(
                name: "IX_IndScheduleRequestTeachers_TeacherId",
                table: "IndScheduleRequestTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndScheduleRequestTeachers");

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
    }
}
