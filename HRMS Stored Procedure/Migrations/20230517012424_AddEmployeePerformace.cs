using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class AddEmployeePerformace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_AddEmployeePerformance
                            @UserID VARCHAR(100),
                            @ReviewBy VARCHAR(100),
                            @About VARCHAR(100),
                            @PerformanceReview VARCHAR(250),
                            @DateReview VARCHAR(100),
                            @Status bit,
                            @DeleteStatus bit
                        AS
                        BEGIN
                            INSERT INTO EmployeePerformances (UserID, ReviewBy, About, PerformanceReview, DateReview, Status, DeleteStatus)
                            VALUES (@UserID, @ReviewBy, @About, @PerformanceReview, @DateReview, @Status, @DeleteStatus);
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_AddEmployeePerformance";
            migrationBuilder.Sql(sp);
        }
    }
}
