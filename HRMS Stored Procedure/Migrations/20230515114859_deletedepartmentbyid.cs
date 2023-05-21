using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class deletedepartmentbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_DeleteDepartmentById
                            @DeptId INT
                        AS
                        BEGIN
                            DELETE FROM Departments
                            WHERE DeptId = @DeptId;
                        END
                        ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_DeleteDepartmentById";
            migrationBuilder.Sql(sp);
        }
    }
}
