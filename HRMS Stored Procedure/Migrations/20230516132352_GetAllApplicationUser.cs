using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class GetAllApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @" CREATE PROCEDURE GetAllApplicationUser
            AS
            BEGIN
                SELECT* from AspNetUsers;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE getalldepartment";
            migrationBuilder.Sql(sp);
        }
    }
}
