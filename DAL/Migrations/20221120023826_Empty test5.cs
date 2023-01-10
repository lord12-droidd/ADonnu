﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Emptytest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6acb304-de51-43c0-b032-eb8cf0588090", "6de9b3aa-fbb4-4520-800b-eb8b0c2a25ee", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1ed899e-3f2d-4dcd-a2c8-56200c26ef5c", "a2ed47ac-c0de-4b91-917a-bdd62e3ddc98", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2ab5bd4-80c9-40f4-ab34-71ccb149740a", "4e925486-a63c-44bb-8698-78fb245c49f2", "Secretary", "SECRETARY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2ab5bd4-80c9-40f4-ab34-71ccb149740a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6acb304-de51-43c0-b032-eb8cf0588090");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1ed899e-3f2d-4dcd-a2c8-56200c26ef5c");
        }
    }
}
