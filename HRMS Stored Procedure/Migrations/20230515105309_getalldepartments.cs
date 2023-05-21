using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class getalldepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @" CREATE PROCEDURE SP_GetAllDepartment
            AS
            BEGIN
                SELECT* from Departments;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetAllDepartment";
            migrationBuilder.Sql(sp);
        }
    }
}
