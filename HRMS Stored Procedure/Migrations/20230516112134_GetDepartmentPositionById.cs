using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class GetDepartmentPositionById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetDepartmentPositionById
                        @no INT
                    AS
                    BEGIN
                        SELECT *
                        FROM DepartmentPositions
                        WHERE No = @no;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE GetDepartmentPositionById";
            migrationBuilder.Sql(sp);
        }
    }
}
