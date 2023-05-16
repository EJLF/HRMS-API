﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class DeleteDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE DeleteDepartmentPosition
                            @no INT
                        AS
                        BEGIN
                            DELETE FROM DepartmentPositions
                            WHERE No = @no;
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE DeleteDepartmentPosition";
            migrationBuilder.Sql(sp);
        }
    }
}
