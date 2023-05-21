using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class GetAllEmployeePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @" CREATE PROCEDURE SP_GetAllEmployeePerformance
            AS
            BEGIN
                SELECT* from EmployeePerformances;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetAllEmployeePerformance";
            migrationBuilder.Sql(sp);
        }
    }
}
