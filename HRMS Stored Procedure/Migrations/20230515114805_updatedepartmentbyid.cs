using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class updatedepartmentbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdateDepartmentById
                        @DeptId INT,
                        @NewDeptName VARCHAR(100)
                    AS
                    BEGIN
                        UPDATE Departments
                        SET DeptName = @NewDeptName
                        WHERE DeptId = @DeptId;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdateDepartmentById";
            migrationBuilder.Sql(sp);
        }
    }
}
