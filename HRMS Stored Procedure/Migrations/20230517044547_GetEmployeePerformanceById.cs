using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class GetEmployeePerformanceById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_GetEmployeePerformanceById
                        @no INT
                    AS
                    BEGIN
                        SELECT *
                        FROM EmployeePerformances
                        WHERE No = @no;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetEmployeePerformanceById";
            migrationBuilder.Sql(sp);
        }
    }
}
