using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class addDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_AddDepartmentPosition
                            @deptId INT,
                            @posId INT
                        AS
                        BEGIN
                            INSERT INTO DepartmentPositions (DepartmentId,PositionId)
                            VALUES (@deptId,@posId);
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_AddDepartmentPosition";
            migrationBuilder.Sql(sp);
        }
    }
}
