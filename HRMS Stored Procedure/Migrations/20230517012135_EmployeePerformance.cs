using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class EmployeePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af5e013-fe2a-4f30-be10-4785c8b1e374");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f81c0866-f65d-464f-bf7d-924677736861");

            migrationBuilder.CreateTable(
                name: "EmployeePerformances",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReviewBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformanceReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DateReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePerformances", x => x.No);
                    table.ForeignKey(
                        name: "FK_EmployeePerformances_AspNetUsers_ReviewBy",
                        column: x => x.ReviewBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePerformances_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e659726-0f2c-4d59-9bfa-f31de2ac82f9", "62527939-49e3-4bfe-8cd1-c2209987972b", "Employee", "EMPLOYEE" },
                    { "990483ad-cf10-47cc-a4d1-087721126099", "d44648b2-103d-49a8-af77-e015bfa04e1a", "Manager", "MANAGER" },
                    { "cb0e59a1-90a3-47fb-82a5-24cfe44f354b", "d47bf0db-67f0-4ebc-ad2a-91c9ec6fa31f", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActiveStatus", "Barangay", "City", "ConcurrencyStamp", "DateHired", "DateOfBirth", "DeleteStatus", "DepartmentId", "Email", "EmailConfirmed", "EmployeeType", "FirstName", "FullName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "PostalCode", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb873458-a5cc-4247-81b9-3b2094dd0c56", 0, true, "Barangay", "City", "775f82d5-c031-429e-90e3-08420777a1f4", new DateTime(2023, 5, 17, 9, 21, 34, 955, DateTimeKind.Local).AddTicks(725), new DateTime(2023, 5, 17, 9, 21, 34, 955, DateTimeKind.Local).AddTicks(712), false, 1, "administrator@pjli.com", true, null, "Admin", "Administrator", "Male", "trator", false, null, "is", "ADMINISTRATOR@PJLI.COM", "ADMINISTRATOR@PJLI.COM", "AQAAAAEAACcQAAAAEMzreHPsPfJbmfrcMNWrjWvkot3gGM6sCVriKrnIcW5wEYh3sFlzHgmU0pepsdv/AQ==", "09236253623", null, false, 1, "1234", "", "State", "Street", false, "administrator@pjli.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb0e59a1-90a3-47fb-82a5-24cfe44f354b", "eb873458-a5cc-4247-81b9-3b2094dd0c56" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformances_ReviewBy",
                table: "EmployeePerformances",
                column: "ReviewBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformances_UserID",
                table: "EmployeePerformances",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePerformances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e659726-0f2c-4d59-9bfa-f31de2ac82f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990483ad-cf10-47cc-a4d1-087721126099");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb0e59a1-90a3-47fb-82a5-24cfe44f354b", "eb873458-a5cc-4247-81b9-3b2094dd0c56" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb0e59a1-90a3-47fb-82a5-24cfe44f354b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb873458-a5cc-4247-81b9-3b2094dd0c56");

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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActiveStatus", "Barangay", "City", "ConcurrencyStamp", "DateHired", "DateOfBirth", "DeleteStatus", "DepartmentId", "Email", "EmailConfirmed", "EmployeeType", "FirstName", "FullName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "PostalCode", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f81c0866-f65d-464f-bf7d-924677736861", 0, true, "Barangay", "City", "e669fa9f-a79f-44e7-bb4b-1e72a8da4ba9", new DateTime(2023, 5, 16, 22, 46, 45, 51, DateTimeKind.Local).AddTicks(9890), new DateTime(2023, 5, 16, 22, 46, 45, 51, DateTimeKind.Local).AddTicks(9877), false, 1, "administrator@pjli.com", true, null, "Admin", "Administrator", "Male", "trator", false, null, "is", "ADMINISTRATOR@PJLI.COM", "ADMINISTRATOR@PJLI.COM", "AQAAAAEAACcQAAAAEHDLw4MckyIuHZG0ybOvLJIrbziNDY8P0y56cGcwI8zB4so2TATT9dYwhvvySpMEpQ==", "09236253623", null, false, 1, "1234", "", "State", "Street", false, "administrator@pjli.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7af5e013-fe2a-4f30-be10-4785c8b1e374", "f81c0866-f65d-464f-bf7d-924677736861" });
        }
    }
}
