using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class GetAllDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @" CREATE PROCEDURE SP_GetAllDepartmentPosition
            AS
            BEGIN
                SELECT* from DepartmentPositions;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetAllDepartmentPosition";
            migrationBuilder.Sql(sp);
        }
    }
}
