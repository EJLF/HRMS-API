using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class updateDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_UpdateDepartmentPosition
                        @no INT,
                        @NewDeptId INT,
                        @NewPosId INT
                    AS
                    BEGIN
                        UPDATE DepartmentPositions
                        SET DepartmentId = @NewDeptId, PositionId = @NewPosId
                        WHERE No = @no;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_UpdateDepartmentPosition";
            migrationBuilder.Sql(sp);
        }
    }
}
