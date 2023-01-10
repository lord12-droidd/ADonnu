using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class connectteachentwithuserent5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bcb757d-0552-41bc-bb1e-0a408bc4e7d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e89ee06-e337-41ca-87fc-4159dc1a2f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca1d64a-ccf3-4346-bf0d-f80e9e182ebc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dba9f083-7c70-4497-9d1a-42252e8c4d7b", "2b0806ea-5613-4298-b4b5-8f06dc006999", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de407cad-0b09-48a8-acd9-a366ea5976d5", "a8ef69e2-c8c4-4425-97f8-3cda9309332f", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c386fe0-73b1-40c8-9155-7f6d9d5e42a6", "fefa2a5e-e8f8-4147-ae83-8197eadf150f", "Secretary", "SECRETARY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c386fe0-73b1-40c8-9155-7f6d9d5e42a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dba9f083-7c70-4497-9d1a-42252e8c4d7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de407cad-0b09-48a8-acd9-a366ea5976d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e89ee06-e337-41ca-87fc-4159dc1a2f77", "1081fab9-b0be-4028-9a7e-6e3d986fa260", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bcb757d-0552-41bc-bb1e-0a408bc4e7d1", "a24c4a8a-16e3-440a-ba2b-8c6072f146db", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eca1d64a-ccf3-4346-bf0d-f80e9e182ebc", "f6117397-6fa2-4658-baae-bbed1864d4cd", "Secretary", "SECRETARY" });
        }
    }
}
