using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class getallpositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @" CREATE PROCEDURE SP_GetAllPositions
            AS
            BEGIN
                SELECT* from Positions;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetAllPositions";
            migrationBuilder.Sql(sp);
        }
    }
}
