using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class getdepartmentbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetDepartmentById
                        @DeptId INT
                    AS
                    BEGIN
                        SELECT *
                        FROM Departments
                        WHERE DeptId = @DeptId;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE GetDepartmentById";
            migrationBuilder.Sql(sp);
        }
    }
}
