using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class UpdateEmployeePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdateEmployeePerformance
                        @no INT,
                        @newUserID VARCHAR(100),
                        @ReviewBy VARCHAR(100),
                        @About VARCHAR(100),
                        @PerformanceReview VARCHAR(250),
                        @DateReview VARCHAR(100),
                        @Status bit,
                        @DeleteStatus bit
                    AS
                    BEGIN
                        UPDATE EmployeePerformances
                        SET UserID = @newUserID, ReviewBy = @ReviewBy, About = @About, PerformanceReview = @PerformanceReview, DateReview = @DateReview, Status = @Status, DeleteStatus = @DeleteStatus
                        WHERE No = @no;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdateEmployeePerformance";
            migrationBuilder.Sql(sp);
        }
    }
}
