using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class automigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7af5e013-fe2a-4f30-be10-4785c8b1e374", "cc77292b-70b2-4e5d-9b83-3267bb2f6d58", "Administrator", "ADMINISTRATOR" },
                    { "950b3f5c-aaa6-4600-802d-90d486ff8873", "ad9d0d46-6ce7-4ca0-81ad-9d0bac1e0be1", "Employee", "EMPLOYEE" },
                    { "bc7cc645-3d1d-491f-ae31-1ac4b222990c", "b471b03f-655e-43fb-816b-b0ae40148d2f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 1, "Human Resource" },
                    { 2, "Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PosId", "PositionName" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Team Leader" },
                    { 3, "Associate" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActiveStatus", "Barangay", "City", "ConcurrencyStamp", "DateHired", "DateOfBirth", "DeleteStatus", "DepartmentId", "Email", "EmailConfirmed", "EmployeeType", "FirstName", "FullName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "PostalCode", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f81c0866-f65d-464f-bf7d-924677736861", 0, true, "Barangay", "City", "e669fa9f-a79f-44e7-bb4b-1e72a8da4ba9", new DateTime(2023, 5, 16, 22, 46, 45, 51, DateTimeKind.Local).AddTicks(9890), new DateTime(2023, 5, 16, 22, 46, 45, 51, DateTimeKind.Local).AddTicks(9877), false, 1, "administrator@pjli.com", true, null, "Admin", "Administrator", "Male", "trator", false, null, "is", "ADMINISTRATOR@PJLI.COM", "ADMINISTRATOR@PJLI.COM", "AQAAAAEAACcQAAAAEHDLw4MckyIuHZG0ybOvLJIrbziNDY8P0y56cGcwI8zB4so2TATT9dYwhvvySpMEpQ==", "09236253623", null, false, 1, "1234", "", "State", "Street", false, "administrator@pjli.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7af5e013-fe2a-4f30-be10-4785c8b1e374", "f81c0866-f65d-464f-bf7d-924677736861" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "950b3f5c-aaa6-4600-802d-90d486ff8873");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7cc645-3d1d-491f-ae31-1ac4b222990c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7af5e013-fe2a-4f30-be10-4785c8b1e374", "f81c0866-f65d-464f-bf7d-924677736861" });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PosId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PosId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af5e013-fe2a-4f30-be10-4785c8b1e374");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f81c0866-f65d-464f-bf7d-924677736861");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PosId",
                keyValue: 1);
        }
    }
}
