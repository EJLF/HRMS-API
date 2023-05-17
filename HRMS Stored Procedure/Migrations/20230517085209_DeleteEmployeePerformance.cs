using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class DeleteEmployeePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE DeleteEmployeePerformanceById
                            @No INT
                        AS
                        BEGIN
                            DELETE FROM EmployeePerformances
                            WHERE No = @No;
                        END
                        ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE DeleteEmployeePerformanceById";
            migrationBuilder.Sql(sp);
        }
    }
}
